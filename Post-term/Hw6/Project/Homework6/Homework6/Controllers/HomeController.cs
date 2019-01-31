using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework6.Models;
using Homework6.Models.FrontViewModel;

namespace Homework6.Controllers
{
    public class HomeController : Controller
    {


        WWIContext db = new WWIContext();


        // GET: People
        public ActionResult Index(String searchData)
        {
            searchData = Request.QueryString["searchBar"];

            if (String.IsNullOrEmpty(searchData))
            {
                ViewBag.display = false;
                return View();
            }
            else
            {
                ViewBag.display = true;
                ViewBag.isValid = db.People.Count(p => p.FullName.Contains(searchData));
                
                return View(db.People.Where(p => p.FullName.Contains(searchData)).ToList());
            }
        }

       
        public ActionResult Details(int? id)
        {
            FEViewModel myVM = new FEViewModel();

            myVM.People = db.People.Find(id);

            ViewBag.display = false;

            
            if (id == null || myVM.People == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            else if (myVM.People.Customers2.Count() > 0)  
            {
                
                ViewBag.display = true;

                
                var customerID = myVM.People.Customers2.First().CustomerID;
                myVM.Customers = db.Customers.Find(customerID);

                
                int orderCount = myVM.Customers
                                     .Orders.SelectMany(i => i.Invoices)
                                     .SelectMany(il => il.InvoiceLines)
                                     .Count();
                var grossSales = myVM.Customers
                                     .Orders.SelectMany(i => i.Invoices)
                                     .SelectMany(il => il.InvoiceLines)
                                     .Sum(s => s.ExtendedPrice);
                var grossProfit = myVM.Customers
                                      .Orders.SelectMany(i => i.Invoices)
                                      .SelectMany(il => il.InvoiceLines)
                                      .Sum(s => s.LineProfit);
                myVM.InvoiceLines = myVM.Customers
                                        .Orders.SelectMany(i => i.Invoices)
                                        .SelectMany(il => il.InvoiceLines)
                                        .OrderByDescending(p => p.LineProfit)
                                        .Take(10).ToList();

                ViewBag.OrderCount = orderCount;
                ViewBag.GrossSales = grossSales;
                ViewBag.GrossProfit = grossProfit;

            }

            return View(myVM);
        }
    }
}