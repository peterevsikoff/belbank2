using BelBank.Interfaces;
using BelBank.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelBank.Repository
{
    public class CategoryRepository:IProductCategory
    {
        private ApplicationContext db;
        public CategoryRepository(ApplicationContext context)
        {
            db = context;
        }
        public IEnumerable<Category> AllCategories => db.Categories;

        public List<Category> ct => db.Categories.ToList();

        public void SaveCategory(Category cat)
        {
            db.Entry(cat).State = EntityState.Added;
            
            db.SaveChanges();
        }
        
        public void DeleteCategory(Category cat)
        {
            db.Categories.Remove(cat);
            db.SaveChanges();
        }
        //public Category EditCategoryGet() //не все пути выдают результат
        //{
        //    
        //    //    return db.Categories.FirstOrDefault(x => x.Id == id);
        //    
        //}
        public void EditCategoryPost(Category cat)
        {
            db.Categories.Update(cat);
            db.SaveChanges();
        }
    }
}
