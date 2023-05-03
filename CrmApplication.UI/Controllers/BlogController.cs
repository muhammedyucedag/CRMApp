using CrmApplication.BLL;
using CrmApplication.DAL.EntitiyFramework;
using CrmApplication.Entites;
using CrmApplication.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrmApplication.UI.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        PostManager postManager = new PostManager(new EfPostRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

        private readonly INotificationService _notificationService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(INotificationService notificationService, IWebHostEnvironment webHostEnvironment)
        {
            _notificationService = notificationService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Blog post, IFormFile file)
        {
            post.PostImage = "";
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
                        string path = Path.Combine(wwwrootPath + "/images/post/", newFileName);

                        using (var fileStram = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(fileStram);
                        }

                        post.PostImage = newFileName;

                    }
                    postManager.Create(post);
                    _notificationService.Notification(NotifyType.Success, $" {post.PostTitle} isimli ürünü başarılı bir şekilde kayıt edildi.");
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

        public IActionResult CreateBlogPartial()
        {
            List<SelectListItem> categoryvalues = (from x in
                  categoryManager.ListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = categoryvalues;

            return PartialView("_BlogCreatePartialView", new Blog());
        }
    }
}
