using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.Models
{
    public class CountrySearchViewModel
    {
        [DisplayName("Select Sort Column:")]
        public string SortColumn { get; set; }

        public List<SelectListItem> Columns { get; set; } = new List<SelectListItem>();
    }
}
