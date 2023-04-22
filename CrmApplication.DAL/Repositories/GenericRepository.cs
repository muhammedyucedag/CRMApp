using CrmApplication.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmApplication.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class
    {
        CrmContext context = new CrmContext();
        public void Create(TEntity entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }

        public List<TEntity> ListAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id)!;
        }
    }
}
