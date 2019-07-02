using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.Models
{
    public class PresidentialViewModel
    {
        [DisplayName("Select Country:")]
        public string Country { get; set; }

        public List<SelectListItem> Countries { get; set; } = new List<SelectListItem>();
    }
}
