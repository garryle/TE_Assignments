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
         * Given an array of non-empty strings, return a Dictionary<string, string> where for every different string in the array,
         * there is a key of its first character with the value of its last character.
         *
         * BeginningAndEnding(["code", "bug"]) → {"b": "g", "c": "e"}
         * BeginningAndEnding(["man", "moon", "main"]) → {"m": "n"}
         * BeginningAndEnding(["muddy", "good", "moat", "good", "night"]) → {"g": "d", "m": "t", "n": "t"}
         */
        public Dictionary<string, string> BeginningAndEnding(string[] words)
        {
            //create an empty list to return
            Dictionary<string, string> bandE = new Dictionary<string, string>();

            //create loop
            foreach (string word in words)
            {
                string firstLetter = word.Substring(0, 1);
                string lastLetter = word.Substring(word.Length - 1);

                if (bandE.ContainsKey(firstLetter)) 
                    {
                    bandE[firstLetter] = lastLetter;
                    }
                else
                    {
                    bandE.Add(firstLetter, lastLetter);
                    }
            }
            return bandE;
        }
    }
}
