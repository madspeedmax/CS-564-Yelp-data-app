﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelpApp.Models;

namespace YelpApp.Controllers
{
    public class BusinessSearchController : BaseController
    {
        const int RecordsPerPage = 5;

        public ActionResult Index(BusinessSearch model)
        {
            if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
            {
                //var results = db.Businesses
                //    .Join(db.Categories,
                //    business => business.Business_ID,
                //    category => category.Business_ID,
                ////    (business, category) => new BusinessCategoryView { Business_ID = business.Business_ID, Category = category.Category })
                //    .Where(b => (b.Business_City == model.City || model.City == null)
                //    && (b.Business_State == model.State || model.State == null)
                //    && (b.Category == model.Category || model.Category == null))
                //    .OrderBy(b => b.Business_Name);

                var results = (from b in db.Businesses
                               join c in db.Categories on b.Business_ID equals c.Business_ID into bc
                               from c in bc.DefaultIfEmpty()
                               select new BusinessCategoryView()
                               {
                                   Business_ID = b.Business_ID,
                                   Business_Name = b.Business_Name,
                                   Category = c.Category,
                                   Business_City = b.Business_City,
                                   Business_State = b.Business_State,
                                   Business_Full_Address = b.Business_Full_Address
                               })
                                .Where(b => (b.Business_City == model.City || model.City == null)
                                && (b.Business_State == model.State || model.State == null)
                                && (b.Category == model.Category || model.Category == null))
                                .OrderBy(bcat => bcat.Business_Name);

                var pageIndex = model.Page ?? 1;
                model.SearchResults = results.ToPagedList(pageIndex, RecordsPerPage);
            }
            return View(model);
        }
    }
}