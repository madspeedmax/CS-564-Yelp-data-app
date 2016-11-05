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
            db.Businesses.Add(Business);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}