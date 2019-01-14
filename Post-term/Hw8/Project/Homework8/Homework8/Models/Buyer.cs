using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework8.Models
{
    public class Buyer
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

    }
}