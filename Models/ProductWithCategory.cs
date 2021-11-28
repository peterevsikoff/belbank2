using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelBank.Models
{
    public class ProductWithCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameCategory { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Note { get; set; }
        public string NoteSpec { get; set; }
    }
}
