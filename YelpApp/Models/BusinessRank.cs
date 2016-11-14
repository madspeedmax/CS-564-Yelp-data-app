using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YelpApp.Models
{
    public class BusinessRank
    {
        public string Category { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<BusinessRankResult> RankResults { get; set; }
        public string SearchButton { get; set; }
    }
}