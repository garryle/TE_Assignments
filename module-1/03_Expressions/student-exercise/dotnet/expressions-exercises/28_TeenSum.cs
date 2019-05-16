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
         Given 2 ints, a and b, return their sum. However, "teen" values in the range 13..19 inclusive, are
         extra lucky. So if either value is a teen, just return 19.
         TeenSum(3, 4) → 7
         TeenSum(10, 13) → 19
         TeenSum(13, 2) → 19
         */
        public int TeenSum(int a, int b)
        {
            if (a == 13 || a == 14 || a == 15 || a == 16 || a == 17 || a == 18 || a == 19 ||
                b == 13 || b == 14 || b == 15 || b == 16 || b == 17 || b == 18 || b == 19)
                return 19;

            else
                return (a + b);
        }
    }
}
