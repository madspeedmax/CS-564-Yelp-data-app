using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelpApp.DAL;

namespace YelpApp.Controllers
{
    public class BaseController : Controller
    {
        protected MyDbContext db { get; set; }

        public BaseController()
        {
            db = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}