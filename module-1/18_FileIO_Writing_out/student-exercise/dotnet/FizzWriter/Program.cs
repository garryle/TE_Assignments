using System;
using System.Collections.Generic;
using System.IO;
namespace FizzWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = $@"{Environment.CurrentDirectory}\..\..\..\..";
            string fileName = "FizzBuzz.txt";
            string fullPath = Path.Combine(directory, fileName);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, false))
                {
                    for (int i = 1; i <= 300; i++) 
                    {
                        if (i % 3 == 0 && i % 5 == 0)
                        {
                            sw.WriteLine(i + "  FizzBuzz");
                        }
                        else if (i % 3 == 0)
                        {
                            sw.WriteLine(i + "  Fizz");
                        }
                        else if (i % 5 == 0)
                        {
                            sw.WriteLine(i + "  Buzz");
                        }
                        else
                        {
                            sw.WriteLine(i);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to create file.");
                Console.WriteLine(e.Message);
            }
        }
    }
}
