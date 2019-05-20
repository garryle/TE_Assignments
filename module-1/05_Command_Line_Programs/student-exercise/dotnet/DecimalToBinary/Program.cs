using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter in a series of decimal values (separated by spaces):");
            string strInput = Console.ReadLine();
            string [] strInputAr = strInput.Split(' ');

            for (int i = 0; i < strInputAr.Length; i++)
            {
                string binary = "";

                int valueToConvert = int.Parse(strInputAr[i]);
                while (valueToConvert > 0)
                {
                    binary = (valueToConvert % 2) + binary;
                    valueToConvert = valueToConvert / 2;
                }
                Console.WriteLine(strInputAr[i] + " in binary is " + binary);
            }
            Console.Read();

        }
    }
}
