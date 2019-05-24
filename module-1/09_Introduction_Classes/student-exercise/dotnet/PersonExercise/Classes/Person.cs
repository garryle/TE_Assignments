using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        //Methods

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public bool IsAdult()
        {
            if (Age <= 17)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
