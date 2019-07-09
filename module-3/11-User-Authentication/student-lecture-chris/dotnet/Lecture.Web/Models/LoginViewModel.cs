﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.Models
{
    public class LoginViewModel
    {
        [DisplayName("Username")]
        [Required]
        public string Username { get; set; }

        [DisplayName("Password")]
        [Required]
        public string Password { get; set; }
    }
}
