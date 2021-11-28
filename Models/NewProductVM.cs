using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BelBank.Models
{
    public class NewProductVM
    {
        public SelectList Categ { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Note { get; set; }
        public string NoteSpec { get; set; }
        public int CategoryId { get; set; }
    }
}
