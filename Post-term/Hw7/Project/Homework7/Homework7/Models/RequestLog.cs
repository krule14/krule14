using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework7.Models
{
    [Table("RequestLog")]
    public class RequestLog
    {
        public int ID { get; set; }

        public DateTime? TimeNow { get; set; }

        [Required]
        public string Request { get; set; }

        [Required]
        public string IP { get; set; }

        [Required]
        public string BrowserType { get; set; }
    }
}