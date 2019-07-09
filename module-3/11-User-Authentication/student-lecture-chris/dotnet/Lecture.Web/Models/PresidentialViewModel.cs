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
        public string ErrorMessage { get; set; } = "";

        [DisplayName("Select Country:")]
        public string Country { get; set; }

        public List<SelectListItem> Countries { get; set; } = new List<SelectListItem>();
    }
}
