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
    public class ProductManager : IProductService
    {
        IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public void Create(Product product)
        {
            productDal.Create(product);
        }

        public void Delete(Product product)
        {
            productDal.Delete(product);
        }

        public void Update(Product product)
        {
            productDal.Update(product);
        }

        public Product Get(int id)
        {
            return productDal.Get(id);
        }

        public List<Product> ListAll()
        {
            return productDal.ListAll();
        }
      
    }
}
