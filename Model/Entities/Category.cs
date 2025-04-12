using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Category : CoreEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; }
         
    }
}
