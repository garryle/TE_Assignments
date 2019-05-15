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
      Given 2 positive int values, return the larger value that is in the range 10..20 inclusive,
      or return 0 if neither is in that range.
      Max1020(11, 19) → 19
      Max1020(19, 11) → 19
      Max1020(11, 9) → 11
      */
        public int Max1020(int a, int b)
        {
            int result =  0;

            // check first value to see if it between 10 .. 20 inclusively
            bool aInRange = a >= 10 && a <= 20;

            //check second value to see if it is between 10..20 incluseive
            bool bInRange = b >= 10 && b <= 20;

            // if either value is true return the larger one
            if (aInRange || bInRange)
            {
                result = a;

                if ((b > a && bInRange) || (b < a && !aInRange))
                {
                    result = b;
                }
            }
            return result;
        }

    }
}
