using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExistingDB.Models.Manual
{
    public class ShoeCategoryJunction
    {
        public long Id { get; set; }
        public long ShoeId { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public Shoe Shoe { get; set; }
    }
}
