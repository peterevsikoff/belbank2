using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelBank.Models
{
    public class ProductList
    {
        public IEnumerable<Product> Products { get; set; }
        public SelectList Categ { get; set; }
       // public string[] cttt { get; set; }
        public string Name { get; set; }
    }
}
