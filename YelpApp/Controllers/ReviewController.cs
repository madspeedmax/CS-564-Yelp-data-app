using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YelpApp.Models;

namespace YelpApp.Controllers
{
    public class ReviewController : BaseController
    {
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create(string businessID)
        {
            if (string.IsNullOrEmpty(businessID) || db.Businesses.Find(businessID) == null)
            {
                return HttpNotFound();
            }
            //var model = new Review();
            ViewData["BusinessName"] = db.Businesses.Find(businessID).Business_Name;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Review Review)
        {
            Review.Review_ID = Guid.NewGuid().ToString();
            Review.Business_ID = Request.QueryString["businessID"];

            if (ModelState.IsValid)
            {
                if (db.Users.Where(u => u.User_ID == Review.User_ID).FirstOrDefault() == null)
                {
                    var user = new User();
                    user.User_ID = Review.User_ID;
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                db.Reviews.Add(Review);
                db.SaveChanges();
                return RedirectToAction("Details", "Business", new { businessID = Review.Business_ID });
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Reviews.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewData["businessName"] = db.Businesses.Find(model.Business_ID).Business_Name;
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Business", new { businessID = review.Business_ID });
            }
            return View(review);
        }
    }
}