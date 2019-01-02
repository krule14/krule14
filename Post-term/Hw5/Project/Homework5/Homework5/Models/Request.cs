using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Homework5.Models
{
    public class Request
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required, StringLength(10)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required, StringLength(10)]
        public string ApptName { get; set; }

        [Required]
        public int UnitNumber { get; set; }

        [Required, StringLength(600)]
        public string Explanation { get; set; }

        [Required]
        public bool Permission { get; set; }

        public DateTime TimeStamp { get; set; }

        public Request()
        {
            TimeStamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{base.ToString()}: {ApptName} {UnitNumber} Time= {TimeStamp} Name= {FirstName + " " + LastName} Phone Number= {PhoneNumber} Explanation={Explanation} Permission= {Permission} ";

        }
    }
}