﻿using CrmApplication.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmApplication.BLL.Abstract
{
    public interface IEmployeeService
    {
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        Employee Get(int id);
        List<Employee> ListAll();
    }
}
