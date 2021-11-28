using BelBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelBank.Interfaces
{
    public interface IProductCategory
    {
        IEnumerable<Category> AllCategories { get; }

        public void SaveCategory(Category cat) { }

        public void DeleteCategory(Category cat) { }

        

        //public void EditCategory(int id) { }//не все пути выдают результа

       

        public void EditCategoryPost(Category cat) { }


        public List<Category> ct { get; }
    }
}
