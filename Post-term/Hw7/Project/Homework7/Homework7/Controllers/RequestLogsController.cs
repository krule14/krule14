using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework7.DAL;
using Homework7.Models;

namespace Homework7.Controllers
{
    public class RequestLogsController : Controller
    {
        private RequestLogContext db = new RequestLogContext();

        // GET: RequestLogs
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListOfQueries()
        {
            return View(db.RequestLogs.ToList());
        }
        public JsonResult Sticker(string userInput)
        {

            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["ApiKey"];
            string apiURL = "https://api.giphy.com/v1/stickers/translate?api_key=" + apiKey + "&s=" + userInput;
            Debug.WriteLine(apiURL);
            Console.WriteLine(apiURL);

            WebRequest apiRequest = WebRequest.Create(apiURL);
            WebResponse getResponse = apiRequest.GetResponse();

            Stream data = apiRequest.GetResponse().GetResponseStream();

            string conStr = new StreamReader(data).ReadToEnd();



            var serialize = new System.Web.Script.Serialization.JavaScriptSerializer();
            var jsonObj = serialize.DeserializeObject(conStr);


            var dbCon = db.RequestLogs.Create();//might be problem here with "RequestLogs" could be requestLog
            dbCon.TimeNow = DateTime.Now;
            dbCon.Request = userInput;
            dbCon.IP = Request.UserHostAddress;
            dbCon.BrowserType = Request.UserAgent;
            db.RequestLogs.Add(dbCon);//Same problem?
            db.SaveChanges();

            data.Close();
            getResponse.Close();

            return Json(jsonObj, JsonRequestBehavior.AllowGet);
        }

    }
}
