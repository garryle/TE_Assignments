using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {

            int length;
            string scale;

            Console.WriteLine("Please enter the length.");
            length = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Is the measurement in (m)eter or (f)eet?");
            scale = Console.ReadLine();

            if (scale.Equals("m"))
            {
                float feet = (int)(length * 3.2808399f);
                Console.WriteLine(length + "m is " + feet + "f.");
            }
            else
            {
                float meter = (int)(length * 0.3048f);
                Console.WriteLine(length + "f is " + meter + "m.");
            }
        }
    }
}
