using CrmApplication.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CrmApplication.DAL.Abstract
{
    public interface IPostDal : IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory();
    }
}
