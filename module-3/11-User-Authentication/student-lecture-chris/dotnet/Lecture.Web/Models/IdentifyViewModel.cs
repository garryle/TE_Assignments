using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Web.Models;

namespace Lecture.Web.Models
{
    public class IdentifyViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [DisplayName("Phone:")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [DisplayName("Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(35, 80, ErrorMessage = "Gotta be between 35 and 80")]
        [DisplayName("Age:")]
        public int Age { get; set; }

        [JobTitle("President")]
        [DisplayName("Job Title:")]
        public string JobTitle { get; set; }
    }
}
