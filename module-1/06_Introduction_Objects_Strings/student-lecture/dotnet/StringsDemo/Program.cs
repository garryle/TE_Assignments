using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ada Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.

            Console.WriteLine("First and Last Characters. " + name[0] + name[name.Length - 1]);
            // Output: A
            // Output: e

            // Console.WriteLine("First and Last Character. ");

            // 2. How do we write code that prints out the first three characters
            // Output: Ada
            int startIndex = 0;
            int strLen = 3;
            Console.WriteLine("First 3 characters: " + name.Substring(startIndex,strLen));

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

            Console.WriteLine("Last 3 characters: " + name.Substring(0, 3) + name.Substring(name.Length - 3,3));

            // 4. What about the last word?
            // Output: Lovelace

            string[] ar = name.Split(' ');
            Console.WriteLine("Last Word: " + ar[ar.Length - 1]);

            // Console.WriteLine("Last Word: ");

            // 5. Does the string contain inside of it "Love"?
            // Output: true

            Console.WriteLine("Contains \"Love\"" + name.Contains("Love") );


            // 6. Where does the string "lace" show up in name?
            // Output: 8

            Console.WriteLine("Index of \"lace\": " + name.Contains("lace") );

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3

            // Console.WriteLine("Number of \"a's\": ");

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"

            // Console.WriteLine(name);

            // 9. Set name equal to null.

            // 10. If name is equal to null or "", print out "All Done".

            Console.ReadLine();
        }
    }
}