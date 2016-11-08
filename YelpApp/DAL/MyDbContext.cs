﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YelpApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace YelpApp.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("YelpConnection")
        {
            Database.SetInitializer<MyDbContext>(new MyDbInitializer());
        }

        public DbSet<Business> Businesses { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}