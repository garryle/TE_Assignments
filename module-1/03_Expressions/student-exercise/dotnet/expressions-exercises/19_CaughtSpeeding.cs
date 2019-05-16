using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         You are driving a little too fast, and a police officer stops you. Write code to compute the result,
         encoded as an int value: 0=no ticket, 1=small ticket, 2=big ticket. If speed is 60 or less, the
         result is 0. If speed is between 61 and 80 inclusive, the result is 1. If speed is 81 or more, the
         result is 2. Unless it is your birthday -- on that day, your speed can be 5 higher in all cases.
         CaughtSpeeding(60, false) → 0    
         CaughtSpeeding(65, false) → 1
         CaughtSpeeding(65, true) → 0
         */

        //0 = speed =< 60
        //1 = 61 >= speed <= 80
        //2 = speed =< 81
        // birthday = 60 < speed

        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if (!(isBirthday))
            {
                if (speed <= 60)
                return 0;

            if (speed > 60 && speed <= 80)
                return 1;
            else
                return 2;
            }
            else if (speed <= 65)
                return 0;
            else if (speed > 65 && speed <= 85)
                return 1;
            else
                return 2;
        }
    }
}
