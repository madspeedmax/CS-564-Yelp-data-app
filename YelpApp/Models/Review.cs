using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace YelpApp.Models
{
    public class Review
    {
        [Key]
        public string Review_ID { get; set; }
        public string Business_ID { get; set; }
        public string User_ID { get; set; }
        public int Stars { get; set; }
        public DateTime Date { get; set; }
    }
}