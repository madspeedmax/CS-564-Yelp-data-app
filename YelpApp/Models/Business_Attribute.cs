using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YelpApp.Models
{
    public class Business_Attribute
    {
        [Key, Column(Order = 0)]
        [DisplayName("Business ID")]
        public string Business_ID { get; set; }

        [Key, Column(Order = 1)]
        public string Attribute { get; set; }

        [Key, Column(Order = 2)]
        public string Value { get; set; }
    }
}