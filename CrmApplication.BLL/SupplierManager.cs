using CrmApplication.BLL.Abstract;
using CrmApplication.DAL.Abstract;
using CrmApplication.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmApplication.BLL
{
    public class SupplierManager : ISupplierService
    {
        ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal SupplierDal)
        {
            _supplierDal = SupplierDal;
        }

        public void Create(Supplier Supplier)
        {
            _supplierDal.Create(Supplier);
        }

        public void Delete(Supplier Supplier)
        {
            _supplierDal.Delete(Supplier);
        }

        public void Update(Supplier Supplier)
        {
            _supplierDal.Update(Supplier);
        }

        public Supplier Get(int id)
        {
            return _supplierDal.Get(id);
        }

        public List<Supplier> ListAll()
        {
            return _supplierDal.ListAll();
        }
       
    }
}
