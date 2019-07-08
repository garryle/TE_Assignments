using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Web.Models
{
    public class NewReviewViewModel
    {
        [DisplayName("Enter your name:")]
        public string Username { get; set; }

        [DisplayName("How many stars:")]
        public int Rating { get; set; }

        [DisplayName("Provide a title:")]
        public string Title { get; set; }

        [DisplayName("Review:")]
        public string Message { get; set; }

        public DateTime ReviewDate { get; set; } = new DateTime();

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
