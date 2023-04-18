using CrmApplication.BLL;
using CrmApplication.DAL.EntitiyFramework;
using CrmApplication.Entites;
using Microsoft.AspNetCore.Mvc;

namespace CrmApplication.UI.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
        public IActionResult Index()
        {
            List<Customer> list = customerManager.ListAll();
            return View(list);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            customerManager.Create(customer);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditCustomerPartial(int id)
        {
            Customer customer = customerManager.Get(id);
            return PartialView("_CustomerEditPartialView", customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            customerManager.Update(customer);
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
            customerManager.Delete(customer);
            return RedirectToAction(nameof(Index));
        }
    }
}
