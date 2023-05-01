using CrmApplication.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmApplication.Entites
{
    public class Blog : EntityBase
    {
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string? PostImage { get; set; }
        public DateTime PostCreateDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
