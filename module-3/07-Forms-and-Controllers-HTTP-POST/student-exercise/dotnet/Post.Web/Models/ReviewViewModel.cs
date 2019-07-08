using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Web.Models
{
    public class ReviewViewModel
    {
        public string Username { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime ReviewDate { get; set; }

        public List<Review> posts { get; set; } = new List<Review>();
    }
}
