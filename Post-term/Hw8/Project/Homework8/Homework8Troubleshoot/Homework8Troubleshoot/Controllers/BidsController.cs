using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework8Troubleshoot.DAL;
using Homework8Troubleshoot.Models;
using Newtonsoft.Json;

namespace Homework8Troubleshoot.Controllers
{
    public class BidsController : Controller
    {
        private AuctionHouseContext db = new AuctionHouseContext();

        // GET: Bids
        public ActionResult Index()
        {
            var bid = db.Bid.Include(b => b.Buyer1).Include(b => b.Item1);
            return View(bid.ToList());
        }

        // GET: Bids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.Bid.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // GET: Bids/Create
        public ActionResult Create()
        {
            ViewBag.Buyer = new SelectList(db.Buyer, "BID", "Name");
            ViewBag.Item = new SelectList(db.Item, "IID", "Name");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BidID,Item,Buyer,Price")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                bid.Timestamp = DateTime.Now;
                db.Bid.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Buyer = new SelectList(db.Buyer, "BID", "Name", bid.Buyer);
            ViewBag.Item = new SelectList(db.Item, "IID", "Name", bid.Item);
            return View(bid);
        }

        // GET: Bids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.Bid.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            ViewBag.Buyer = new SelectList(db.Buyer, "BID", "Name", bid.Buyer);
            ViewBag.Item = new SelectList(db.Item, "IID", "Name", bid.Item);
            return View(bid);
        }

        public JsonResult BidFinder(int? id)
        {
            var targetItem = db.Item.Find(id);
            

            if(targetItem.Bid.Count() > 0)
            {
                var results = db.Item.SelectMany(m => m.Bid)
                              .Where(m => m.Item == id)
                              .OrderBy(m => m.Timestamp)
                              .ToList();
                string jsonRes = JsonConvert.SerializeObject(results);

                return Json(jsonRes, JsonRequestBehavior.AllowGet);

            }else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
