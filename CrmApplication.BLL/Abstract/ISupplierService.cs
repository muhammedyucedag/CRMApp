using CrmApplication.Entites;

namespace CrmApplication.BLL.Abstract
{
    public interface ISupplierService
    {
        void Create(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(Supplier supplier);
        Supplier Get(int id);
        List<Supplier> ListAll();

    }
}
