﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace color_mile2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MileConverter()
        {
            ViewBag.Message = "PHHHHTTTT! I FOUND THE THINGY!!!";

            return View();
        }
        [HttpPost]
        public ActionResult ColorMixer()
        {
            return View();
        }
    }

}