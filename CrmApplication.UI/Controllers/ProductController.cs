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

        public ProductController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            List<Product> list = productManager.ListAll();
            return View(list);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
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
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
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
