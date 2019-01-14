using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework8.Models
{
    public class Item
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
     
        [Required]
        public string Description { get; set; }

        
        public Seller Seller { get; set; }

        
        public IEnumerable<SelectListItem> Sellers { get; set; }
    }
}