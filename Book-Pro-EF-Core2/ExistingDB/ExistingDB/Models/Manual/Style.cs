using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExistingDB.Models.Manual
{
    // Using attributes to override EF Core data modeling conventions

    [Table("Colors")]
    public class Style
    {
        [Key]
        [Column("Id")]
        public long UniqueIdent { get; set; }
        [Column("Name")]
        public string StyleName { get; set; }
        public string MainColor { get; set; }
        public string HighlightColor { get; set; }

        [InverseProperty(nameof(Shoe.Style))]
        public IEnumerable<Shoe> Products { get; set; }
    }
}
