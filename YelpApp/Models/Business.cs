﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace YelpApp.Models
{
    public class Business
    {
        [Key]
        public String Business_ID { get; set; }
        public string Business_Name { get; set; }
        public string Business_City { get; set; }
        public string Business_State { get; set; }
        public string Business_Full_Address { get; set; }
        public bool Business_Open { get; set; }
    }
}