using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExistingDB.Models.Manual
{
    [Table("SalesCampaigns")]
    public class SalesCampaign
    {
        public long Id { get; set; }
        public string Slogan { get; set; }
        public int? MaxDiscount { get; set; }
        public DateTime? LaunchDate { get; set; }
        public long ShoeId { get; set; }
        public Shoe Shoe { get; set; }
    }
}
