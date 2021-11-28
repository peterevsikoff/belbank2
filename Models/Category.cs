using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelBank.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public List<Product> products { get; set; }
    }
}
