using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            String name = "Ada Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            Console.WriteLine("First and Last Character. " + name[0] + name[name.Length-1]);

            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            int startIndex = 0;
            int strLen = 3; 
            Console.WriteLine("First 3 characters: " + name.Substring(startIndex,strLen) );

            // 3. Now print out the first three and the last three characters
            // Output: Adaace
          
            Console.WriteLine("First 3 and Last 3 characters: " + name.Substring(0,3) + name.Substring(name.Length - 3,3)   );


            // 4. What about the last word?
            // Output: Lovelace

            string[] ar = name.Split(' '); 
             Console.WriteLine("Last Word: " + ar[ar.Length-1]);

            // 5. Does the string contain inside of it "Love"?
            // Output: true

            Console.WriteLine("Contains \"Love\"" + name.Contains("love") );

            // 6. Where does the string "lace" show up in name?
            // Output: 8

             Console.WriteLine("Index of \"lace\": " + name.IndexOf("lace"));

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3

            //split on a and find the array length
            //string nameInLower = name.ToLower();
            //string[] array = nameInLower.Split('a');
            //int count = array.Length-1; 

            //loop to find the index and then do substring to the right of the index until index = -1
            string nameInLower = name.ToLower();
            int count = 0;
            int index = nameInLower.IndexOf('a');
            while(index != -1)
            {
                count++;
                nameInLower = nameInLower.Substring(index+1);
                index = nameInLower.IndexOf('a');
            }

            
            //loop through each character and test it
            //int count = 0;
            //string nameInCaps = name.ToUpper(); 
            //for (int i =0; i< nameInCaps.Length; i++)
            //{
            //    if (nameInCaps[i] == 'A')
            //        count++; 
            //}

            Console.WriteLine("Number of \"a's\": " + count);
            // 8. Replace "Ada" with "Ada, Countess of Lovelace"

            name = name.Replace("Ada", "Ada, Countess of"); 

             Console.WriteLine(name);

            // 9. Set name equal to null.
            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            if (String.IsNullOrEmpty(name))
                Console.WriteLine("All Done");

            

            Console.ReadLine();
        }
    }
}