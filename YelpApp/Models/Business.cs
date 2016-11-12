using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace YelpApp.Models
{
    public class Business
    {
        [Key]
        [DisplayName("Business ID")]
        public string Business_ID { get; set; }

        [DisplayName("Name")]
        public string Business_Name { get; set; }

        [DisplayName("City")]
        public string Business_City { get; set; }

        [DisplayName("State")]
        public string Business_State { get; set; }

        [DisplayName("Address")]
        public string Business_Full_Address { get; set; }

        [DisplayName("Open?")]
        public bool Business_Open { get; set; }

        public IEnumerable<Review> reviews { get; set; }
    }
}