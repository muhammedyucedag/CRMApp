using CrmApplication.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmApplication.Entites
{
    public class Category : EntityBase
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual List<Blog> Posts { get; set; }
    }
}
