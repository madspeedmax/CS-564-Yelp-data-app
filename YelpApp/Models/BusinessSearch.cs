using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace YelpApp.Models
{
    public class BusinessSearch
    {
        public int? Page { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public IPagedList<BusinessCategoryView> SearchResults { get; set; }
        public string SearchButton { get; set; }
    }
}