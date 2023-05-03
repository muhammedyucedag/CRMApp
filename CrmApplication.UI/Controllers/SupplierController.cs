using CrmApplication.BLL;
using CrmApplication.DAL.EntitiyFramework;
using CrmApplication.Entites;
using CrmApplication.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrmApplication.UI.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly INotificationService _notificationService;

        public SupplierController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        SupplierManager supplierManager = new SupplierManager(new EfSupplierRepository());
        public IActionResult Index()
        {
            List<Supplier> suppliers = supplierManager.ListAll();
            return View(suppliers);
        }
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    supplierManager.Create(supplier);
                    _notificationService.Notification(NotifyType.Success, $" {supplier.CompanyName} isimli tedarikçi başarılı bir şekilde kayıt edildi.");
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

        public IActionResult CreateSupplierPartial()
        {
            return PartialView("_SupplierCreatePartialView", new Supplier());
        }

        public IActionResult EditSupplierPartial(int id)
        {
            Supplier supplier = supplierManager.Get(id);
            return PartialView("_SupplierEditPartialView", supplier);
        }

        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    supplierManager.Update(supplier);
                    _notificationService.Notification(NotifyType.Success, $" {supplier.CompanyName} isimli tedarikçi başarılı bir şekilde güncellendi.");
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

        public IActionResult DeleteSupplierPartial(int id)
        {
            Supplier supplier = supplierManager.Get(id);
            return PartialView("_SupplierDeletePartialView", supplier);
        }

        [HttpPost]
        public IActionResult Delete(Supplier supplier)
        {
            // model dolu gelecek
            try
            {
                supplierManager.Delete(supplier);
                _notificationService.Notification(NotifyType.Success, $" {supplier.CompanyName} isimli tedarikçi başarılı bir şekilde silindi.");
            }
            catch (Exception ex)
            {
                _notificationService.Notification(NotifyType.Error, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
