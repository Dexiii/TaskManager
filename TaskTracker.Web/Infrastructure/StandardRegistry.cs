using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using TaskTracker.Web.Data;
using TaskTracker.Web.Models;

namespace TaskTracker.Web.Infrastructure
{
    public class StandardRegistry: Registry
    {
        public StandardRegistry()
        {
            For<Microsoft.AspNet.Identity.IUserStore<ApplicationUser>>().Use < Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>>();
            For<System.Data.Entity.DbContext>().Use(() => new ApplicationDbContext());
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                //scan.With(new ControllerConvention());
            });
        }
    }
}