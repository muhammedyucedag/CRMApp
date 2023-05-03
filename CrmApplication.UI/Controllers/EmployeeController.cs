using CrmApplication.BLL;
using CrmApplication.DAL.EntitiyFramework;
using CrmApplication.Entites;
using CrmApplication.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrmApplication.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        // toplu şekilde metotları kapatmak için CTRL+M,O
        EmployeeManager EmployeeManager = new EmployeeManager(new EfEmployeeEepository());
        private readonly INotificationService _notificationService;

        public EmployeeController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            List<Employee> list = EmployeeManager.ListAll();
            return View(list);
        }

        [HttpPost]
        public IActionResult Create(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeManager.Create(Employee);
                    _notificationService.Notification(NotifyType.Success, $" {Employee.NameSurname} isimli müşteriyi başarılı bir şekilde kayıt edildi.");
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

        public IActionResult CreateEmployeePartial()
        {
            return PartialView("_EmployeeCreatePartialView", new Employee());
        }

        public IActionResult EditEmployeePartial(int id)
        {
            Employee Employee = EmployeeManager.Get(id);
            return PartialView("_EmployeeEditPartialView", Employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee Employee)    
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeManager.Update(Employee);
                    _notificationService.Notification(NotifyType.Success, $" {Employee.NameSurname} isimli müşteri başarılı bir şekilde güncellendi.");
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

        public IActionResult DeleteEmployeePartial(int id)
        {
            Employee Employee = EmployeeManager.Get(id);
            return PartialView("_EmployeeDeletePartialView", Employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee Employee)
        {
            try
            {
                EmployeeManager.Delete(Employee);
                _notificationService.Notification(NotifyType.Success, $" {Employee.NameSurname} isimli müşteri başarılı bir şekilde silindi.");
            }
            catch (Exception ex)
            {
                _notificationService.Notification(NotifyType.Error, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateEmployeeState(int id)
        {
            var employee = EmployeeManager.Get(id);
            employee.Status = !employee.Status; // true ise false yap tam terse çevir
            EmployeeManager.Update(employee);
            _notificationService.Notification(NotifyType.Success, $" {employee.NameSurname} isimli müşterinin durumu başarılı bir şekilde güncellendi.");

            return Ok();
        }
    }
}
