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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Create(Customer customer)
        {
            _customerDal.Create(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }

        public Customer Get(int id)
        {
            return _customerDal.GetCustomer(id);
        }

        public List<Customer> ListAll()
        {
            return _customerDal.ListAll();
        }
       
    }
}
