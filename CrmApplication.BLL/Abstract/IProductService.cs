using CrmApplication.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmApplication.BLL.Abstract
{
    public interface IProductService
    {
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
        Product Get(int id);
        List<Product> ListAll();
    }
}
