using BelBank.Interfaces;
using BelBank.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelBank.Controllers
{
    public class ProductWithCategoryController : Controller
    {
        private readonly IProducts products;
        private readonly IProductCategory productsCategory;
        private readonly IProductWithCategory productWithCategory;

        public ProductWithCategoryController(IProducts iproducts, IProductCategory iproductcategory, IProductWithCategory iproductWithCategory)
        {
            products = iproducts;
            productsCategory = iproductcategory;
            productWithCategory = iproductWithCategory;
        }

        public ViewResult List(string category)
        {
            //string _category = category;
            //IEnumerable<Product> prods;
            //string currentCategory = "";
            //if (string.IsNullOrEmpty(category))
            //{
            //    prods = products.Products.OrderBy(i => i.Id);
            //}
            //else
            //{
            //    prods = products.Products.Where(i => i.CategoryId == 1);

            //}
            //currentCategory = _category;

            ViewBag.Title = "Товары";
            ProductsListViewModel obj = new ProductsListViewModel();
            //obj.getAllProductWithCategories = productWithCategory.allProductsWithCategories;


            obj.getAllProducts = products.Products;
            obj.currentCategory = "Все товары";
            return View(obj);
        }
    }
}
