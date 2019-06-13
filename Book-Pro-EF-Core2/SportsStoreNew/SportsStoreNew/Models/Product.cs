using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreNew.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public string Category { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal PurchasePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal RetailPrice { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
