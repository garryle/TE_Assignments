using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {

            int tempInput;
            string scaleInput;

            Console.WriteLine("Please enter the temperature.");
            tempInput = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Is the temperature in (C)elcius, or (F)arenheit?");
            scaleInput = Console.ReadLine();

            if (scaleInput.Equals("C"))
            {
                int tempF = (int)(tempInput * 1.8 + 32);
                Console.WriteLine(tempInput + "C is " + tempF + "F.");
            }
            else
            {
                int tempC = (int)((tempInput - 32) / 1.8);
                Console.WriteLine(tempInput + "F is " + tempC + "C.");
            }
        }
    }
 
    
}
