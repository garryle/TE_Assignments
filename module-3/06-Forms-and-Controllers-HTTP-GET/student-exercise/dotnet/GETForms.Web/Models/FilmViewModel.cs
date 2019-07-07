using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GETForms.Web.Models
{
    public class FilmViewModel
    {
        [DisplayName("Minimum Length")]
        public int minLength { get; set; }

        [DisplayName("Maximum Length")]
        public int maxLength { get; set; }

        [DisplayName("Genres")]
        public string genre { get; set; }

        public List<SelectListItem> Genres = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Action" },
            new SelectListItem() { Text = "Animation" },
            new SelectListItem() { Text = "Children" },
            new SelectListItem() { Text = "Classics" },
            new SelectListItem() { Text = "Comedy" },
            new SelectListItem() { Text = "Documentary" },
            new SelectListItem() { Text = "Family" },
            new SelectListItem() { Text = "Foreign" },
            new SelectListItem() { Text = "Games" },
            new SelectListItem() { Text = "Horror" },
            new SelectListItem() { Text = "Music" },
            new SelectListItem() { Text = "Sci-Fi" },
            new SelectListItem() { Text = "Sports" },
            new SelectListItem() { Text = "Travel" },
            new SelectListItem() { Text = "Drama" },
            new SelectListItem() { Text = "New" },
        };


    }
}
