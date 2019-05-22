using System;
using System.Collections.Generic;

namespace DictionaryCollection
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Hash fun section 
            HashSet<string> studentsWhoHaveTurnedInLaptops = new HashSet<string>();

            studentsWhoHaveTurnedInLaptops.Add("luna");
            if (studentsWhoHaveTurnedInLaptops.Contains("luna"))
                Console.WriteLine("Great job luna");
            else
                Console.WriteLine("luna turn in your laptop!");
           */
            

            Console.WriteLine("Welcome to the Person / Height Database");
            Console.WriteLine();

            Console.Write("Would you like to enter another person (yes/no)? ");
            string input = Console.ReadLine().ToLower();

            // 1. Let's create a new Dictionary that could hold string, ints
            //      | "Josh"    | 70 |
            //      | "Bob"     | 72 |
            //      | "John"    | 75 |
            //      | "Jack"    | 73 |
            Dictionary<string, int> dictionaryVariable = new Dictionary<string, int>();

            while (input == "yes" || input == "y")
            {
                Console.Write("What is the person's name?: ");
                string name = Console.ReadLine();

                Console.Write("What is the person's height (in inches)?: ");
                int height = int.Parse(Console.ReadLine());

                // 2. Check to see if that name is in the dictionary
                //      bool exists = dictionaryVariable.ContainsKey(key)
                bool exists = dictionaryVariable.ContainsKey(name);

                if (!exists)
                {
                    Console.WriteLine($"Adding {name} with new value.");
                    // 3. Put the name and height into the dictionary
                    //      dictionaryVariable[key] = value;
                    //      OR dictionaryVariable.Add(key, value);
                    dictionaryVariable.Add(name, height);

                }
                else
                {
                    Console.WriteLine($"Overwriting {name} with new value.");
                    // 4. Overwrite the current key with a new value
                    //      dictionaryVariable[key] = value;
                    //dictionaryVariable[name] = height; 
                    //Remove and re-add
                    bool successFullyRemoved = dictionaryVariable.Remove(name);
                }


                Console.WriteLine();
                Console.Write("Would you like to enter another person (yes/no)? ");
                input = Console.ReadLine().ToLower();
            }

            Console.Write("Type \"all\" to print all names OR \"search\" to print out single name: ");
            input = Console.ReadLine().ToLower();

            if (input == "search")
            {
                Console.Write("Which name are you looking for? ");
                input = Console.ReadLine();

                //5. Let's get a specific name from the dictionary
                if (dictionaryVariable.ContainsKey(input))
                {
                    //get it and print out the info for input key
                    Console.WriteLine ($"{input}'s height is {dictionaryVariable[input]}");
                }
                else
                {
                    Console.WriteLine($"key {input} not found");
                }

            }
            else if (input == "all")
            {
                Console.WriteLine();
                Console.WriteLine(".... printing ...");

                //6. Let's print each item in the dictionary
                foreach(KeyValuePair<string,int> kvp in dictionaryVariable)
                {
                    string name = kvp.Key;
                    int height = kvp.Value;
                    Console.WriteLine(name + " " + height); 
                }

            }

            double total = 0; 
            foreach (int height in dictionaryVariable.Values)
            {
                total += height; 
            }
            double averageHeight = total / dictionaryVariable.Count;
            Console.WriteLine($"Average height is {averageHeight}");

            Console.WriteLine();
            Console.WriteLine("Done...");

            Console.ReadLine();
        }

        static void PrintDictionary(Dictionary<string, int> database)
        {
            // Looping through a dictionary involves using a foreach loop
            // to look at each item, which is a key-value pair
        }
    }
}
