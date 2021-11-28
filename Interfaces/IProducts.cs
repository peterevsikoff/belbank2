using BelBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelBank.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> Products { get; }
        public void DeleteProduct(Product prod) { }

        public void SaveProduct(Product prod) { }

        public void SaveNewProduct(NewProductVM newprod, int id) { }

        public void EditNewProduct(NewProductVM newprod, int id) { }
    }
}
