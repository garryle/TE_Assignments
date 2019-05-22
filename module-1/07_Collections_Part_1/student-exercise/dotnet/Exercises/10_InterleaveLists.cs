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
         Given two lists of Integers, interleave them beginning with the first element in the first list followed
         by the first element of the second. Continue interleaving the elements until all elements have been interwoven.
         Return the new list. If the lists are of unequal lengths, simply attach the remaining elements of the longer
         list to the new list before returning it.
		 DIFFICULTY: HARD
         InterleaveLists( [1, 2, 3], [4, 5, 6] )  ->  [1, 4, 2, 5, 3, 6]
         */
        public List<int> InterleaveLists(List<int> listOne, List<int> listTwo)
        {
            //Create empty list to return
            List<int> interWovenList = new List<int>();

            int smallerArraySize = listOne.Count;
            if (listOne.Count > listTwo.Count)
            {
                smallerArraySize = listTwo.Count;
            }
            //create a loop to access both lists at the same time by index
            for (int i = 0; i < smallerArraySize; i++)
            {
                //alternate adding the items starting with list one
                interWovenList.Add(listOne[i]);
                interWovenList.Add(listTwo[i]);
            }

            //if one of the lists were bigger, add the rest
            if (smallerArraySize < listOne.Count)
            {
                int numberOfItemsToAdd = listOne.Count - smallerArraySize;
                interWovenList.AddRange(listOne.GetRange(smallerArraySize, numberOfItemsToAdd));
            }
            else if (smallerArraySize < listTwo.Count)
            {
            int numberOfItemsToAdd = listTwo.Count - smallerArraySize;
            interWovenList.AddRange(listTwo.GetRange(smallerArraySize, numberOfItemsToAdd));
            }
            return interWovenList;
        }
    }
}
