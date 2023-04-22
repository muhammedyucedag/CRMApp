using CrmApplication.BLL;
using CrmApplication.DAL.EntitiyFramework;
using CrmApplication.Entites;
using Microsoft.AspNetCore.Mvc;

namespace CrmApplication.UI.Controllers
{
    public class SupplierController : Controller
    {
        SupplierManager supplierManager = new SupplierManager( new EfSupplierRepository());
        public IActionResult Index()
        {
            List<Supplier> suppliers = supplierManager.ListAll();
            return View(suppliers);
        }
        public IActionResult Create(Supplier supplier)
        {
            supplierManager.Create(supplier);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditSupplierPartial(int id)
        {
            Supplier supplier = supplierManager.Get(id);
            return PartialView("_SupplierEditPartialView", supplier);
        }

        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            supplierManager.Update(supplier);
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
            supplierManager.Delete(supplier);
            return RedirectToAction(nameof(Index));
        }

    }
}
