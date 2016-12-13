using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace YelpApp.Models
{
    public class User
    {
        public User()
        {
            Name = "NoName";
            Elite = false;
        }

        [Key]
        [DisplayName("User ID")]
        public string User_ID { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [DisplayName("Elite")]
        [Required]
        public bool Elite { get; set; }
    }
}