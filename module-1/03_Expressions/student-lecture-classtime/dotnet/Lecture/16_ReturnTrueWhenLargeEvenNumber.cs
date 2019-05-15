using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureExample
    {
        /*
        16. Return "Big Even Number" when number is even, larger than 100, and a multiple of 5.
            Return "Big Number" if the number is just larger than 100.
            Return empty string for everything else.
            TOPIC: Complex Expression
        */
        public string ReturnBigEvenNumber(int number)
        {
            string retStr = "";
            if (number > 100)
            {
                if (number %2==0 && number%5==0)
                {
                    retStr = "Big Even Number";
                }
                else
                {
                    retStr = "Big Number";
                }
            }

            //if (  (number%2 ==0)  && (number > 100) && (number%5==0)  )
            //{
            //    retStr = "Big Even Number";
            //}
            //else if (number > 100)
            //{
            //    retStr = "Big Number";
            //}

            return retStr; 
        }
        


    }
}
