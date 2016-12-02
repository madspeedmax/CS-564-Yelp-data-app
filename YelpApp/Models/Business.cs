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
        [Required(ErrorMessage = "Name is required", AllowEmptyStrings = false)]
        public string Business_Name { get; set; }

        [DisplayName("City")]
        [Required]
        public string Business_City { get; set; }

        [DisplayName("State")]
        [Required]
        public string Business_State { get; set; }

        [DisplayName("Address")]
        [Required]
        public string Business_Full_Address { get; set; }

        [DisplayName("Open?")]
        [Required]
        public bool Business_Open { get; set; }

        public IEnumerable<Review> reviews { get; set; }
    }
}