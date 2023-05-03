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
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal EmployeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            EmployeeDal = employeeDal;
        }

        public void Create(Employee employee)
        {
            EmployeeDal.Create(employee);
        }

        public void Delete(Employee employee)
        {
            EmployeeDal.Delete(employee);
        }
        public void Update(Employee employee)
        {
            EmployeeDal.Update(employee);
        }
        public Employee Get(int id)
        {
            return EmployeeDal.Get(id);
        }

        public List<Employee> ListAll()
        {
            return EmployeeDal.ListAll();
        }


    }
}
