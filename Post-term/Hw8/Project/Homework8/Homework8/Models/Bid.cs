using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework8.Models
{
    public class Bid
    {
        public int ID { get; set; }

        [Required]
        public Item Item { get; set; }

        [Required]
        public Buyer Buyer { get; set; }

        [Required]
        public int Price { get; set; }

        public DateTime Timestamp { get; set; }

        public Bid()
        {
            Timestamp = DateTime.Now;
        }

    }
}