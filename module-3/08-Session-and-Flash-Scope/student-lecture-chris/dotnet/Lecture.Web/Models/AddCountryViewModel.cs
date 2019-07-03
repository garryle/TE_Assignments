using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.Models
{
    public class AddCountryViewModel
    {
        public string Name { get; set; }

        public List<string> ExistingCountries { get; set; }
    }
}
