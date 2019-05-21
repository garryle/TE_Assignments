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
        Given a string, return a version where all the "x" have been removed. Except an "x" at the very start or end
        should not be removed.
        StringX("xxHxix") → "xHix"
        StringX("abxxxcd") → "abcd"
        StringX("xabxxxcdx") → "xabcdx"
        */
        public string StringX(string str)
        {
            string addString = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 || i == str.Length - 1)
                {
                    addString += str[i];
                }
                else if (str[i] != 'x')
                {
                    addString += str[i];
                }
                

            }
            return addString; 

        }
    }
}
