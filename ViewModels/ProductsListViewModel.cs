using BelBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelBank.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> getAllProducts { get; set; }

        public IEnumerable<Category> getAllCatigories { get; set; }
        public string currentCategory { get; set; }

        public IEnumerable<ProductWithCategory> getAllProductWithCategories { get; set; }
    }
}
