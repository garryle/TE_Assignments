using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            //List of variables used in program
            int intInput;
            int add = 1;
            int fibA = 0;
            int fibB = 1;

            //Asks user for the number they wish to see the Fibonacci sequence
            Console.Write("Please enter Fibonacci number: ");
            intInput = Convert.ToInt32(Console.ReadLine()); //Converts the string to a number

            Console.WriteLine(fibA);
            while (add <= intInput)
            {
                Console.WriteLine(add);
                add = fibA + fibB;
                fibA = fibB;
                fibB = add;
            }

            //Console.WriteLine("Please enter Fibonacci number: ");
            //string strMaxNumber = Console.ReadLine();
            //int maxNumber = int.Parse(strMaxNumber);

            //int minusTwo = 0;
            //int minusOne = 1;

            //Console.WriteLine("Fibonacci Sequence:");
            //Console.Write("0,1");

            //int myValue = 0;
            //while ((minusOne + minusTwo) < maxNumber)
            //{
            //    myValue = minusTwo + minusOne;
            //    Console.Write("," + myValue);

            //    minusTwo = minusOne;
            //    minusOne = myValue;

            //}
            Console.Read();
        }
    }
}
