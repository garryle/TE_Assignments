using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.Models
{
    public class LaunchPadViewModel
    {
        [DisplayName("Launch Code:")]
        public string LaunchCode { get; set; }
    }
}
