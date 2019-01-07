using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework6.Models.FrontViewModel
{
    public class FEViewModel
    {
        //Model from People 
        public Person People { get; set; }

        //Model from Customer
        public Customer Customers { get; set; }

        //Model from InvoiceLines
        public List<InvoiceLine> InvoiceLines { get; set; }
    }
}