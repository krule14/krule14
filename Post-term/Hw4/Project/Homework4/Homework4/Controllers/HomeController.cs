﻿using System;
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
            return View();
        }
    }
}