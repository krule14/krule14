

namespace Homework8Troubleshoot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("Bid")]
    public partial class Bid
    {
        public int BidID { get; set; }

        public int Item { get; set; }

        public int Buyer { get; set; }

        public int Price { get; set; }

        public DateTime Timestamp { get; set; }

        public virtual Buyer Buyer1 { get; set; }

        public virtual Item Item1 { get; set; }
    }
}