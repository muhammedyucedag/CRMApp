using CrmApplication.BLL;
using CrmApplication.DAL.EntitiyFramework;
using CrmApplication.Entites;
using CrmApplication.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrmApplication.UI.Controllers
{
    public class ProductController : Controller
    {
        // toplu şekilde metotları kapatmak için CTRL+M,O
        ProductManager productManager = new ProductManager(new EfProductRepository());
        private readonly INotificationService _notificationService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(INotificationService notificationService, IWebHostEnvironment webHostEnvironment)
        {
            _notificationService = notificationService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> list = productManager.ListAll();
            return View(list);
        }

        [HttpPost]
        public IActionResult Create(Product product, IFormFile file)
        {
            product.ImageUrl = "";
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        // resim upload işlemi
                        string wwwrootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        string extension = Path.GetExtension(file.FileName);

                        string newFileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwrootPath + "/images/product/", newFileName);

                        using (var fileStram = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(fileStram);
                        }

                        product.ImageUrl = newFileName;

                    }
                    productManager.Create(product);
                    _notificationService.Notification(NotifyType.Success, $" {product.Name} isimli ürünü başarılı bir şekilde kayıt edildi.");
                }
                catch (Exception ex)
                {

                    _notificationService.Notification(NotifyType.Error, ex.Message);
                }
            }
            else

                ModelStateController.CheckIt(_notificationService, ModelState);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateProductPartial()
        {
            return PartialView("_ProductCreatePartialView", new Product());
        }

        public IActionResult EditProductPartial(int id)
        {
            Product product = productManager.Get(id);
            return PartialView("_ProductEditParitalView", product);
        }

        [HttpPost]
        public IActionResult Edit(Product product, IFormFile? file)
        {
         
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        // resim upload işlemi
                        string wwwrootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        string extension = Path.GetExtension(file.FileName);

                        string newFileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwrootPath + "/images/product/", newFileName);

                        using (var fileStram = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(fileStram);
                        }

                        product.ImageUrl = newFileName;

                    }
                    productManager.Update(product);
                    _notificationService.Notification(NotifyType.Success, $" {product.Name} isimli ürünü başarılı bir şekilde güncellendi.");
                }
                catch (Exception ex)
                {

                    _notificationService.Notification(NotifyType.Error, ex.Message);
                }
            }
            else
                ModelStateController.CheckIt(_notificationService, ModelState);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteProductPartial(int id)
        {
            Product product = productManager.Get(id);
            return PartialView("_ProductDeletePartialView", product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            // model dolu gelecek
            try
            {
                productManager.Delete(product);
                _notificationService.Notification(NotifyType.Success, $" {product.Name} isimli ürünü başarılı bir şekilde silindi.");
            }
            catch (Exception ex)
            {
                _notificationService.Notification(NotifyType.Error, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
