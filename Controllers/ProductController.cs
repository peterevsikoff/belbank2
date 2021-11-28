using BelBank.Interfaces;
using BelBank.Models;
using BelBank.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BelBank.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProducts products;
        private readonly IProductCategory productsCategory;

        public ProductController(IProducts iproducts, IProductCategory iproductcategory)
        {
            products = iproducts;
            productsCategory = iproductcategory;
        }
        [Authorize(Roles = "admin, user, userplus")]
        public ViewResult List(string category)
        {
            ViewBag.Title = "Товары";
            ProductsListViewModel obj = new ProductsListViewModel();
            obj.getAllProducts = products.Products;
            obj.getAllCatigories = productsCategory.AllCategories;
            obj.currentCategory = "Все товары";
            return View(obj);
        }


        [Authorize(Roles = "user")]
        public ActionResult Index(int? id, string name)
        {
            IEnumerable<Product> prod = products.Products;
            if (id != null && id != 0)
            {
                prod = prod.Where(p => p.Category.Id == id);
            }
            if (!String.IsNullOrEmpty(name))
            {
                prod = prod.Where(p => p.Name.Contains(name));
            }

            List<Category> categories = productsCategory.ct;
            categories.Insert(0, new Category { NameCategory = "Все", Id = 0 });
            //string[] mass = new string[] { "Еда","Вода","Вкусности"};
            
            ProductList viewModel = new ProductList
            {
                Products = prod.ToList(),
                Categ = new SelectList(categories, "Id", "NameCategory"),
                Name = name
                //cttt = mass
            };
            return View(viewModel);
        }
        [Authorize(Roles = "userplus")]
        public ActionResult IndexPlus(int? id, string name)
        {
            IEnumerable<Product> prod = products.Products;
            if (id != null && id != 0)
            {
                prod = prod.Where(p => p.Category.Id == id);
            }
            if (!String.IsNullOrEmpty(name))
            {
                prod = prod.Where(p => p.Name.Contains(name));
            }

            List<Category> categories = productsCategory.ct;
            categories.Insert(0, new Category { NameCategory = "Все", Id = 0 });
            //string[] mass = new string[] { "Еда","Вода","Вкусности"};

            ProductList viewModel = new ProductList
            {
                Products = prod.ToList(),
                Categ = new SelectList(categories, "Id", "NameCategory"),
                Name = name
                //cttt = mass
            };
            return View(viewModel);
        }

        [Authorize(Roles = "userplus")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            products.DeleteProduct(new Product() { Id = id});
            return RedirectToAction("IndexPlus");
        }
        [Authorize(Roles = "userplus")]
        public IActionResult Create()
        {
            //IEnumerable<Product> prod = products.Products;
            //List<Category> categories = productsCategory.ct;
            //CatList viewmodel = new CatList
            //{
            //    Products = prod.ToList(),
            //    Categ = new SelectList(categories, "Id", "NameCategory")
            //};
            //string[] mass = new string[] { "Еда", "Вода", "Вкусности" };
            //ViewBag.Cat = mass;
            return View();
        }
        [Authorize(Roles = "userplus")]
        [HttpPost]
        public IActionResult Create(Product prod)
        {
            if (ModelState.IsValid)
            {
                products.SaveProduct(prod);
                return RedirectToAction("IndexPlus");
            }

            return View(prod);
        }

        [Authorize(Roles = "userplus")]
        public ActionResult NewProductCreate(int? id)
        {
            //IEnumerable<Product> prod = products.Products;
            //if (id != null && id != 0)
            //{
            //    prod = prod.Where(p => p.Category.Id == id);
            //}
            //if (!String.IsNullOrEmpty(name))
            //{
            //    prod = prod.Where(p => p.Name.Contains(name));
            //}

            List<Category> categories = productsCategory.ct;
            //categories.Insert(0, new Category { NameCategory = "Все", Id = 0 });
            ////string[] mass = new string[] { "Еда","Вода","Вкусности"};

            //ProductList viewModel = new ProductList
            //{
            //    Products = prod.ToList(),
            //    Categ = new SelectList(categories, "Id", "NameCategory"),
            //    Name = name
            //    //cttt = mass
            //};

            NewProductVM vm = new NewProductVM
            {
                Categ = new SelectList(categories, "Id", "NameCategory")

            };
            return View(vm);
        }
        [Authorize(Roles = "userplus")]
        [HttpPost]
        public IActionResult NewProductCreate(NewProductVM newprod, int id)
        {
            if (ModelState.IsValid)
            {
                //products.SaveProduct(prod);
                products.SaveNewProduct(newprod, id);
                return RedirectToAction("IndexPlus");
            }

            return View(newprod);
        }

        [Authorize(Roles = "userplus")]
        public ActionResult NewProductEdit(int? id)
        {
            //IEnumerable<Product> prod = products.Products;
            //if (id != null && id != 0)
            //{
            //    prod = prod.Where(p => p.Id == id);
            //}
            //if (!String.IsNullOrEmpty(name))
            //{
            //    prod = prod.Where(p => p.Name.Contains(name));
            //}

            List<Category> categories = productsCategory.ct;
            //categories.Insert(0, new Category { NameCategory = "Все", Id = 0 });
            ////string[] mass = new string[] { "Еда","Вода","Вкусности"};

            //ProductList viewModel = new ProductList
            //{
            //    Products = prod.ToList(),
            //    Categ = new SelectList(categories, "Id", "NameCategory"),
            //    Name = name
            //    //cttt = mass
            //};
            Product pr = products.Products.FirstOrDefault(p => p.Id == id);
            NewProductVM vm = new NewProductVM
            {
                Name = pr.Name,
                Description = pr.Description,
                Price = pr.Price,
                Note = pr.Note,
                NoteSpec = pr.NoteSpec,
                Categ = new SelectList(categories, "Id", "NameCategory")

            };
            return View(vm);
        }
        [Authorize(Roles = "userplus")]
        [HttpPost]
        public ActionResult NewProductEdit(NewProductVM vm, int id)
        {
            products.EditNewProduct(vm, id);
            return RedirectToAction("IndexPlus");
        }

    }
}
