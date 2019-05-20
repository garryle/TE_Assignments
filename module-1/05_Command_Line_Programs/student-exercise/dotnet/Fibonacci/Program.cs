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
        }
    }
}
