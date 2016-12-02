using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YelpApp.DAL;
using YelpApp.Models;

namespace YelpApp.Controllers
{

    public class BusinessController : BaseController
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Business Business)
        {
            Business.Business_ID = Guid.NewGuid().ToString();

            if (ModelState.IsValid)
            {
                db.Businesses.Add(Business);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Details(string businessID)
        {
            var model = db.Businesses.Find(businessID);
            
            if (model == null)
            {
                return HttpNotFound();
            }

            ViewData["Categories"] = db.Categories.Where(c => c.Business_ID == businessID).ToList();
            ViewData["Attributes"] = db.Attributes.Where(c => c.Business_ID == businessID).ToList();
            ViewData["Checkins"] = db.Checkins.Where(c => c.Business_ID == businessID).ToList();
            return View(model);
        }

        public ActionResult Update(Business Business)
        {
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult Reviews(string businessID)
        {
            ViewData["BusinessID"] = businessID;
            var model = db.Reviews.Where(e => e.Business_ID == businessID).ToList();
            return PartialView(model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Businesses.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Business business)
        {
            if (ModelState.IsValid)
            {
                db.Entry(business).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Business", new { businessID = business.Business_ID });
            }
            return View(business);
        }
    }
}