using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechElevator.Web.Models
{
    public class ComposerViewModel
    {
        public Film Film { get; set; }
        public Music Music { get; set; } = new Music();
    }
}
