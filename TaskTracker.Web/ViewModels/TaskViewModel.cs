using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskTracker.Web.Infrastructure.Mapping;
using TaskTracker.Web.Models;

namespace TaskTracker.Web.ViewModels
{
    public class TaskViewModel : IMapFrom<RTask>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [Display(Name="Regarding")]
        public string RegardingUserName { get; set; }
        //public virtual ApplicationUser Regarding { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Due { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Created { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Modified { get; set; }
    }
}