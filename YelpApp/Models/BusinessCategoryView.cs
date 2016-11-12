using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace YelpApp.Models
{
    public class BusinessCategoryView 
    {
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

        [DisplayName("Category")]
        public string Category { get; set; }
    }

    public class BusinessCategoryViewComparer : IEqualityComparer<BusinessCategoryView>
    {
        public bool Equals(BusinessCategoryView bcv1, BusinessCategoryView bcv2)
        {
            return bcv1.Business_ID == bcv2.Business_ID;
        }

        public int GetHashCode(BusinessCategoryView bcv)
        {
            return bcv.Business_ID.GetHashCode();
        }
    }
}