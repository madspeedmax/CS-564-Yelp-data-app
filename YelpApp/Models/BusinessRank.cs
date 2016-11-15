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
        public string City2 { get; set; }
        public string State2 { get; set; }
        public string City3 { get; set; }
        public string State3 { get; set; }
        public List<BusinessRankResult> RankResults { get; set; }
        public string SearchButton { get; set; }
    }
}