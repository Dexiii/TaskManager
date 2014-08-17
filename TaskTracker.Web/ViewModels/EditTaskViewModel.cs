using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskTracker.Web.Infrastructure.Mapping;
using TaskTracker.Web.Models;

namespace TaskTracker.Web.ViewModels
{
    public class EditTaskViewModel : IMapFrom<RTask>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime Due { get; set; }
    }
}