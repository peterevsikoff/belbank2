using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BelBank.Models
{
    public class CatList
    {
        public IEnumerable<Product> Products { get; set; }
        public SelectList Categ { get; set; }
    }
}
