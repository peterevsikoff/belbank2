using BelBank.Interfaces;
using BelBank.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelBank.Repository
{
    public class ProductRepository: IProducts
    {
        private ApplicationContext db;
        public ProductRepository(ApplicationContext context)
        {
            db = context;
        }
        public IEnumerable<Product> Products => db.Products.Include(c => c.Category);
        public void DeleteProduct(Product prod)
        {
            db.Products.Remove(prod);
            db.SaveChanges();
        }

        public void SaveProduct(Product prod)
        {
            db.Entry(prod).State = EntityState.Added;

            db.SaveChanges();
        }

        public void SaveNewProduct(NewProductVM newprod, int id)
        {
            Product prod = new Product
            {
                Name = newprod.Name,
                Description = newprod.Description,
                Price = newprod.Price,
                Note = newprod.Note,
                NoteSpec = newprod.NoteSpec,
                CategoryId = id
            };
            db.Entry(prod).State = EntityState.Added;

            db.SaveChanges();
        }

        public void EditNewProduct(NewProductVM vm, int id)
        {
            Product p = db.Products.Find(vm.Id);
            p.Name = vm.Name;
            p.Description = vm.Description;
            p.Price = vm.Price;
            p.Note = vm.Note;
            p.NoteSpec = vm.NoteSpec;
            p.CategoryId = id;
            //Product prod = new Product
            //{
            //    Name = vm.Name,
            //    Description = vm.Description,
            //    Price = vm.Price,
            //    Note = vm.Note,
            //    NoteSpec = vm.NoteSpec,
            //    CategoryId = id
            //};
            db.Products.Update(p);
            db.SaveChanges();
        }
    }
}
