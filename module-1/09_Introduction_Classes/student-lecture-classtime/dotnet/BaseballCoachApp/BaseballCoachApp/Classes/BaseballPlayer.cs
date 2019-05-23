using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballCoachApp.Classes
{
    class BaseballPlayer
    {

        static int lastJerseyNum; 

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName; 
            }
        }

        private double _average; 
        public double Average
        {
            get { return _average; }
            set
            {
                if (value >= 0 && value <= 1)
                    _average = value; 
            }
        }

        public int Jersey { get;  } 

        /// <summary>
        /// THis constructor will not initialize any values
        /// </summary>
        public BaseballPlayer()
        {
            Jersey = lastJerseyNum++;
        }

        /// <summary>
        /// Initialize the players name and batting average
        /// </summary>
        /// <param name="n">player name</param>
        /// <param name="a"> batting average</param>
        public BaseballPlayer(string first, string last,  double a)
        {
            FirstName = first;
            LastName = last; 
            Average = a;
            Jersey = lastJerseyNum++; 
        }

        public override string ToString()
        {
            return FirstName + " batting average: " + Average;
        }
    }
}
