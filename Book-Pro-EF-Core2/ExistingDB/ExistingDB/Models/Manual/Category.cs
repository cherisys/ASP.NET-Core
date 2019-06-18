using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExistingDB.Models.Manual
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ShoeCategoryJunction> Shoes { get; set; }
    }
}
