using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class CitySearchViewModel
    {
        // The selected country
        [DisplayName("Choose City:")]
        public string City { get; set; }

        // The choices the user can select from
        public List<SelectListItem> Cities { get; } = new List<SelectListItem>();
    }
}
