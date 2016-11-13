using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace YelpApp.Models
{
    public class Review
    {
        [Key]
        [DisplayName("Review ID")]
        public string Review_ID { get; set; }

        [DisplayName("Business ID")]
        public string Business_ID { get; set; }

        [DisplayName("User ID")]
        public string User_ID { get; set; }

        [Range(1, 5, ErrorMessage = "Stars must be between 1 and 5")]
        public int Stars { get; set; }

        public DateTime Date { get; set; }
    }
}