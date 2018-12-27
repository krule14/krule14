using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chooser()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Converter()
        {
            //1 mile= 1609.344 Meters
            /* 
             * Millim
             * Centim
             * M
             * Kilom
             * 
             * 
             * */

            double Retval = 1609.344;

            string UnitString = Request.QueryString["Metric"];
            double Miles = Convert.ToDouble(Request.QueryString["Miles"]);
            if (UnitString == "M")
            {
                Retval *= Miles;
            }
            else if (UnitString == "Millim")
            {
                Retval *= Miles * 1000;
            }
            else if (UnitString == "Centim")
            {
                Retval *= Miles * 100;
            }
            else if (UnitString == "Kilom")
            {
                Retval *= Miles / 1000;
            }
            else
            {
                return View();
            }

            ViewBag.Message = Miles + " miles is equal to  " + Retval + " " + UnitString + "eters.";

            return View();
        }
    }
}