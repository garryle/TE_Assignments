using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GETForms.Web.Models
{
    public class FilmSearch
    {
        /// <summary>
        /// The minimum length of the film to search for.
        /// </summary>
        [DisplayName("Minimum Length")]
        public int? MinimumLength { get; set; }

        /// <summary>
        /// The maximum length of the film to search for.
        /// </summary>
        [DisplayName("Maximum Length")]
        public int? MaximumLength { get; set; }

        /// <summary>
        /// The genre of the film to search for.
        /// </summary>
        [DisplayName("Genre")]        
        public string Genre { get; set; }

        /// <summary>
        /// The genres available to be searched.
        /// </summary>
        public List<SelectListItem> Genres { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem{ Text = "Comedy", Value="Comedy" },
            new SelectListItem{ Text = "Action", Value = "Action" },
            new SelectListItem{ Text = "Horror", Value = "Horror" },
            new SelectListItem{ Text = "Family", Value = "Family" },
            new SelectListItem{ Text = "Drama", Value = "Drama" },
        };

        /// <summary>
        /// The results returned.
        /// </summary>
        public IList<Film> Results { get; set; } = new List<Film>();
    }
}
