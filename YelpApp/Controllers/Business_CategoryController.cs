using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelpApp.Models;

namespace YelpApp.Controllers
{
    public class Business_CategoryController : BaseController
    {
        // GET: Category
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

            ViewData["BusinessName"] = db.Businesses.Find(businessID).Business_Name;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Business_Category Business_Category)
        {
            Business_Category.Business_ID = Request.QueryString["businessID"];

            if (ModelState.IsValid)
            {
                db.Categories.Add(Business_Category);
                db.SaveChanges();
                return RedirectToAction("Details", "Business", new { businessID = Business_Category.Business_ID });
            }
            return View();
        }
    }
}