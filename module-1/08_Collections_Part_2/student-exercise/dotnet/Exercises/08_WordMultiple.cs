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
         * Given an array of strings, return a Dictionary<string, Boolean> where each different string is a key and value
         * is true only if that string appears 2 or more times in the array.
         *
         * WordMultiple(["a", "b", "a", "c", "b"]) → {"b": true, "c": false, "a": true}
         * WordMultiple(["c", "b", "a"]) → {"b": false, "c": false, "a": false}
         * WordMultiple(["c", "c", "c", "c"]) → {"c": true}
         *
         */
        public Dictionary<string, bool> WordMultiple(string[] words)
        {
            //create an empty list to return
            Dictionary<string, bool> hashMultiples = new Dictionary<string, bool>();

            //create a hash to see if letter is already in
            HashSet<string> alreadyAdded = new HashSet<string>();

            //loop thorugh words
            foreach (string word in words)
            {
                //check if the string is in hash multiples
                if (hashMultiples.ContainsKey(word))
                {
                    hashMultiples[word] = true;
                }
                //if it is, then set value to true
                else
                {//else false
                    hashMultiples[word] = false;
                }

                }


            return hashMultiples;
        }
    }
}
