using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.Models
{
    public class CountryTimeResultsViewModel
    {
        public List<SelectListItem> Columns { get; set; } = new List<SelectListItem>();

        public List<Country> Countries { get; set; } = new List<Country>();
    }
}
