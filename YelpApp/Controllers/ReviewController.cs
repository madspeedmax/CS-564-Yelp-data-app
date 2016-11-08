using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Review Review)
        {
            Review.Review_ID = Guid.NewGuid().ToString();
            db.Reviews.Add(Review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}