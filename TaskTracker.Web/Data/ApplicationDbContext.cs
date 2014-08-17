﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskTracker.Web.Models;
using System.Data.Entity;

namespace TaskTracker.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        //public ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<RTask> Tasks { get; set; }
    }
}