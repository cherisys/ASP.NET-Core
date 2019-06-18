using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExistingDB.Models.Manual
{
    public class ShoeWidth
    {
        public long UniqueIdent { get; set; }
        public string WidthName { get; set; }

        public IEnumerable<Shoe> Products { get; set; }
    }
}
