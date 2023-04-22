using CrmApplication.DAL.Abstract;
using CrmApplication.DAL.Repositories;
using CrmApplication.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmApplication.DAL.EntitiyFramework
{
    public class EfSupplierRepository : GenericRepository<Supplier>,ISupplierDal
    {
    }
}
