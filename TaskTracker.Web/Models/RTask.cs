using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskTracker.Web.Infrastructure.Mapping;
using TaskTracker.Web.ViewModels;

namespace TaskTracker.Web.Models
{
    public class RTask: IMapFrom<CreateTaskViewModel>, IMapFrom<EditTaskViewModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ApplicationUser Regarding { get; set; }

        public DateTime Due { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}