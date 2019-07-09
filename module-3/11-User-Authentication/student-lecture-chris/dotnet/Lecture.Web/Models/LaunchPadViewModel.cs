using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.Models
{
    public class LaunchPadViewModel
    {
        [Required(ErrorMessage = "Needed")]
        [MinLength(28, ErrorMessage = "Fool")]
        [MaxLength(28, ErrorMessage = "Kablam")]
        [DisplayName("Launch Code:")]
        public string LaunchCode { get; set; }
    }
}
