using Microsoft.AspNetCore.Mvc;

namespace CrmApplication.UI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
