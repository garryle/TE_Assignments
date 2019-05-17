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
         Given an array of ints, return true if the array is length 1 or more, and the first element and
         the last element are equal.
         SameFirstLast([1, 2, 3]) → false
         SameFirstLast([1, 2, 3, 1]) → true
         SameFirstLast([1, 2, 1]) → true
         */
         // true if num => 1 and element 0 and -1 are the same.
        
        public bool SameFirstLast(int[] nums)
        {
            if (nums.Length > 0 && nums [0] == nums [nums.Length - 1])

                return true;
            else 
            return false;
        }

    }
}
 