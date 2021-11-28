using BelBank.Interfaces;
using BelBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelBank.Repository
{
    public class ProductWithCategoryRepository : IProductWithCategory
    {
        private ApplicationContext db;
        public ProductWithCategoryRepository(ApplicationContext context)
        {
            db = context;
        }
        
        public IEnumerable<ProductWithCategory> allProductsWithCategories()
        {
            List<ProductWithCategory> list=null;
            var p = db.Products;
            var c = db.Categories;
            foreach (Product prod in p)
            {
                ProductWithCategory newprod = new ProductWithCategory();
                newprod.Id = prod.Id;
                newprod.Name = prod.Name;
                newprod.Note = prod.Note;
                newprod.NoteSpec = prod.NoteSpec;
                newprod.Price = prod.Price;
                list.Add(newprod);
            }
            return list;
        }
        
    }
}
