using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a non-empty string like "Code" return a string like "CCoCodCode".
         StringSplosion("Code") → "CCoCodCode"
         StringSplosion("abc") → "aababc"
         StringSplosion("ab") → "aab"
         */
        public string StringSplosion(string str)
        {
            //create new string that's first letter, first letter second letter, first second third...
            string splodedString = "";

            for (int i = 0; i < str.Length; i++)
            {
                splodedString += str.Substring(0, i + 1);
            }
            return splodedString;
        }
    }
}
