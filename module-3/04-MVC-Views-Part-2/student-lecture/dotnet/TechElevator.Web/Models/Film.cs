using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechElevator.Web.Models
{
    public class Film
    {
        public string Name { get; set; } = "Star Wars";
        public string ImageUrl { get; set; } = "starwars.com";
        public int? Length { get; set; } = 120;
        public int YearReleased { get; set; } = 1979;
        public string Id { get; set; } = "your momma";
    }
}
