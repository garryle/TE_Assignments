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
         Given a List of Integers, and an int value, return true if the int value appears two or more times in
         the list.
         FoundIntTwice( [5, 7, 9, 5, 11], 5 ) -> true
         FoundIntTwice( [6, 8, 10, 11, 13], 8 -> false
         FoundIntTwice( [9, 23, 44, 2, 88, 44], 44) -> true
         */
        public bool FoundIntTwice(List<int> integerList, int intToFind)
        {
            //is it even in the list
            if (integerList.Contains(intToFind))
            {
                integerList.Remove(intToFind); //remove the first one
                if (integerList.Contains(intToFind)) //if there's a second one
                    return true;
                else
                    return false; 
            }
            else
                return false;
           
        }

    }
}
