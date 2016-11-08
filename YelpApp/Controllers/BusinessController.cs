using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelpApp.DAL;
using YelpApp.Models;

namespace YelpApp.Controllers
{

    public class BusinessController : BaseController
    {
        public ActionResult Index()
        {
            var model = db.Businesses.ToList();
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Business Business)
        {
            Business.Business_ID = Guid.NewGuid().ToString();
            db.Businesses.Add(Business);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string businessID)
        {
            var model = db.Businesses.Find(businessID);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Update(Business Business)
        {
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult Reviews(string businessID)
        {
            var model = db.Reviews.Where(e => e.Business_ID == businessID).ToList();
            return PartialView(model);
        }
    }
}