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
         Given 2 int values, return true if they are both in the range 30..40 inclusive, or they are both
         in the range 40..50 inclusive.
         In3050(30, 31) → true
         In3050(30, 41) → false
         In3050(40, 50) → true
         */
        public bool In3050(int a, int b)
        {
            bool aRange1 = 30 <= a && a <= 40;
            bool aRange2 = 40 <= a && a <= 50;
            bool bRange1 = 30 <= b && b <= 40;
            bool bRange2 = 40 <= b && b <= 50;

            return aRange1 && bRange1 || aRange2 && bRange2;
        }

    }
}
