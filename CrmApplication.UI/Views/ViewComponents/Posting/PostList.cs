using CrmApplication.BLL;
using CrmApplication.DAL.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;

namespace CrmApplication.UI.Views.ViewComponents.Post
{
    public class PostList : ViewComponent
    {
        private PostManager postManager = new PostManager(new EfPostRepository());
        public IViewComponentResult Invoke()
        {
            var values = postManager.GetPostListWithCategory();
            return View(values);
        }
    }
}
