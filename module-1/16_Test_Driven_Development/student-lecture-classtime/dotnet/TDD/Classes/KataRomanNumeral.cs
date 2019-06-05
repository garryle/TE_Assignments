using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Classes
{
    public class KataRomanNumeral
    {
        public string GetRomanNumeral(int number)
        {
            string result = "";

            result += Convert(ref number, 1000, "M");
            result += ReplaceSubtraction(ref number, 900, "CM"); 
            result += Convert(ref number, 500, "D");
            result += ReplaceSubtraction(ref number, 400, "CD"); 
            result += Convert(ref number, 100, "C");
            result += ReplaceSubtraction(ref number, 90, "XC");
            result += Convert(ref number, 50, "L");
            result += ReplaceSubtraction(ref number, 40, "XL"); 
            result += Convert(ref number, 10, "X");
            result += ReplaceSubtraction(ref number, 9, "IX"); 
            result += Convert(ref number, 5, "V");
            result += ReplaceSubtraction(ref number,4,"IV" );            
            result += Convert(ref number, 1, "I");

            return result;

        }

        private static string ReplaceSubtraction(ref int number,int replaceNumber, string strReplacement)
        {
            string result = "";
            if (number >= replaceNumber)
            {
                result += strReplacement;
                number = number - replaceNumber;
            }
            return result; 
        }

        private static string Convert(ref int number, int digit, string digitValue)
        {
            string result = "";
            while (number >= digit)
            {
                result += digitValue;
                number = number - digit;
            }
            return result; 
        }
    }
}
