using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YelpApp.Models
{
    public class Business_Checkin
    {
        [Key, Column(Order = 0)]
        [DisplayName("Business ID")]
        public string Business_ID { get; set; }

        [Key, Column(Order = 1)]
        [DisplayName("Sunday")]
        public string Sunday { get; set; }

        [Key, Column(Order = 2)]
        [DisplayName("Monday")]
        public string Monday { get; set; }

        [Key, Column(Order = 3)]
        [DisplayName("Tuesday")]
        public string Tuesday { get; set; }

        [Key, Column(Order = 4)]
        [DisplayName("Wednesday")]
        public string Wednesday { get; set; }

        [Key, Column(Order = 5)]
        [DisplayName("Thursday")]
        public string Thursday { get; set; }

        [Key, Column(Order = 6)]
        [DisplayName("Friday")]
        public string Friday { get; set; }

        [Key, Column(Order = 7)]
        [DisplayName("Saturday")]
        public string Saturday { get; set; }
    }
}