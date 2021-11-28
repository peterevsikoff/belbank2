using BelBank.Interfaces;
using BelBank.Models;
using BelBank.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelBank.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductCategory productsCategory;
        public CategoryController(IProductCategory iproductcategory)
        {
            productsCategory = iproductcategory;
        }
        [Authorize(Roles = "admin")]
        public ViewResult List()
        {
            ViewBag.Title = "Категории";
            ProductsListViewModel obj = new ProductsListViewModel();
            obj.getAllCatigories = productsCategory.AllCategories;
            
            obj.currentCategory = "Все категории";
            return View(obj);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Cteate()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost] 
        public IActionResult Cteate(Category cat)
        {
            if (ModelState.IsValid)
            {
                productsCategory.SaveCategory(cat);
                return RedirectToAction("List");
            }

            return View(cat);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            var cat = productsCategory.AllCategories;
            foreach (Category c in cat)
            {
                if (c.Id == id)
                {
                    return View(c);
                }
            }
            return NotFound();
            
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Edit(Category cat)
        {
            productsCategory.EditCategoryPost(cat);
            return RedirectToAction("List");
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            productsCategory.DeleteCategory(new Category() { Id = id });
            return RedirectToAction("List");
        }
    }
}
