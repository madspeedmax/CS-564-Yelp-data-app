using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace YelpApp.Models
{
    public class BusinessRankResult
    {
        [DisplayName("Category")]
        public string Category { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Number of Reviews")]
        public int ReviewCount { get; set; }

        [DisplayName("Score")]
        public double Score { get; set; }
    }
}