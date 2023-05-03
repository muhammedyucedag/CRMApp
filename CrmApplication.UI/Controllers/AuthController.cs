using CrmApplication.BLL;
using CrmApplication.DAL.EntitiyFramework;
using CrmApplication.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CrmApplication.UI.Controllers
{
    public class AuthController : Controller
    {
        EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeEepository());

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = employeeManager.ListAll().FirstOrDefault(x => x.Mail == model.Email && x.Passwonrd == model.Password);

                if (user != null && user.Status)
                {
                    // Claim giriş yapan kullanıcılıra ait bilgileri tuttuğuımuz alan
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.NameSurname),
                        new Claim(ClaimTypes.Email, user.Mail),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (user == null)
                    {
                        ModelState.AddModelError("", "Kullanıcı bilgileri hatalı");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı aktif değil");
                    }
                }
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}
