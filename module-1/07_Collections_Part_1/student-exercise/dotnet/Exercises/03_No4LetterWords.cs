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
         Given an array of Strings, return a List containing the same Strings in the same order
         except for any words that contain exactly 4 characters.
         No4LetterWords( {"Train", "Boat", "Car"} )  ->  ["Train", "Car"]
         No4LetterWords( {"Red", "White", "Blue"} )  ->  ["Red", "White"]
         No4LetterWords( {"Jack", "Jill", "Jane", "John", "Jim"} )  ->  ["Jim"]
         */
        public List<string> No4LetterWords(string[] stringArray)
        {
            //create a empty list
            //loop through the array
            //add anything not 4 characters
            List<string> returnList = new List<string>();
            for (int i = 0; i < stringArray.Length; i++)
            {
                string temp = stringArray[i];
                if (temp.Length != 4)
                {
                    returnList.Add(temp);
                }
            }

            return returnList;
        }

    }
}
