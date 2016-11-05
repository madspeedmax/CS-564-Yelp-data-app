using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YelpApp.Models;

namespace YelpApp.DAL
{
    public class MyDbInitializer : CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            // create a business to seed the db
            context.Businesses.Add(new Business { Business_Name = "Andrew's Business", Business_City = "Madison", Business_State = "WI" });
            base.Seed(context);
        }
    }
}