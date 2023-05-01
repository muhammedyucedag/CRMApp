using CrmApplication.DAL.Abstract;
using CrmApplication.DAL.Repositories;
using CrmApplication.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CrmApplication.DAL.EntitiyFramework
{
    public class EfPostRepository : GenericRepository<Blog>, IPostDal
    {
        public List<Blog> GetListWithCategory()
        {
            using (var context = new CrmContext())
            {
                return context.Posts.Include(x => x.Category).ToList();
            }
        }
    }
}
