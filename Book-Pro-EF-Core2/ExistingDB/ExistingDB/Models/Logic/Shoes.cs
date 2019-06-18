using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExistingDB.Models.Scaffold
{
    public partial class Shoes
    {
        public decimal PriceIncTax => this.Price * 1.2m;
    }
}
