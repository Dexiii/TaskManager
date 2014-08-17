using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using TaskTracker.Web.Data;
using TaskTracker.Web.Models;

using Microsoft.AspNet.Identity;

namespace TaskTracker.Web.Infrastructure
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IIdentity _identity;
        private readonly ApplicationDbContext _context;

        private ApplicationUser _user;

        public CurrentUser (IIdentity identity, ApplicationDbContext context)
	    {
            _identity = identity;
            _context = context;
	    }

        public ApplicationUser User
        {
            get
            {
                return _user ?? (_user = _context.Users.Find(_identity.GetUserId()));
            }
        }
    }
}