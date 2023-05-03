using CrmApplication.BLL;
using CrmApplication.DAL.EntitiyFramework;
using CrmApplication.Entites;
using CrmApplication.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrmApplication.UI.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {

        // toplu şekilde metotları kapatmak için CTRL+M,O
        CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
        private readonly INotificationService _notificationService;

        public CustomerController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            List<Customer> list = customerManager.ListAll();
            return View(list);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    customerManager.Create(customer);
                    _notificationService.Notification(NotifyType.Success, $" {customer.CompanyName} isimli müşteriyi başarılı bir şekilde kayıt edildi.");
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

        public IActionResult CreateCustomerPartial()
        {
            return PartialView("_CustomerCreatePartialView",new Customer());
        }

        public IActionResult EditCustomerPartial(int id)
        {
            Customer customer = customerManager.Get(id);
            return PartialView("_CustomerEditPartialView", customer);
        }
        
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    customerManager.Update(customer);
                    _notificationService.Notification(NotifyType.Success, $" {customer.CompanyName} isimli müşteri başarılı bir şekilde güncellendi.");
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

        public IActionResult DeleteCustomerPartial(int id)
        {
            Customer customer = customerManager.Get(id);
            return PartialView("_CustomerDeletePartialView", customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            try
            {
                customerManager.Delete(customer);
                _notificationService.Notification(NotifyType.Success, $" {customer.CompanyName} isimli müşteri başarılı bir şekilde silindi.");
            }
            catch (Exception ex)
            {
                _notificationService.Notification(NotifyType.Error, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
