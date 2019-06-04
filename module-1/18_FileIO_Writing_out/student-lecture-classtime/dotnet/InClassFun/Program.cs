using System;
using System.IO;

namespace InClassFun
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
            Console.WriteLine("Do you want to harvest (h) or reap (r) info?");
            string input = Console.ReadLine();
            if (input.ToLower().Equals("h"))
            {
                HarvestInfo();
            }
            else if (input.ToLower().Equals("r"))
            {
                ReapInfo();
            }
            else
            {
                Console.WriteLine("invalid. goodbye");
            }

            Console.WriteLine("press enter to end program");
            Console.ReadLine();
        }

        private static void ReapInfo()
        {
            string dir = @"C:\TestDirectory\InterestingPeople";

            try
            {
                //loop through all the files in the directory and print out all the info for all the people
                foreach (string file in Directory.EnumerateFiles(dir))
                {
                    
                    Console.WriteLine("Here's the dirt on " + Path.GetFileNameWithoutExtension(file));
                    FileInfo fi = new FileInfo(file);
                    Console.WriteLine("we've known his/her secrets since " + fi.CreationTime); 

                    //open the file and print the info
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }                        
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("oops" + e.GetType() + " " + e.Message);
            }

        }

        private static void HarvestInfo()
        {
            string keepGoing = "y";
            while (keepGoing.Equals("y"))
            {
                //prompt for a user name
                Console.WriteLine("whats your name?");
                string name = Console.ReadLine();

                //create a file for that user with the info named their name
                string dir = @"C:\TestDirectory\InterestingPeople";
                string fullName = Path.Combine(dir, name);

                try
                {
                    using (StreamWriter sw = new StreamWriter(fullName, false))
                    {
                        Console.WriteLine("what is your favorite color?");
                        string favColor = Console.ReadLine();
                        sw.WriteLine("Favorite color: " + favColor);
                        Console.WriteLine("whats your ssn?");
                        sw.WriteLine("SSN: " + Console.ReadLine());
                        Console.WriteLine("whats your mothers maiden name?");
                        sw.WriteLine("MMN: " + Console.ReadLine());
                        Console.WriteLine("whats your first pet name?");
                        sw.WriteLine("first pet: " + Console.ReadLine());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("oops");
                }

                Console.WriteLine("Do you want to enter info for another user? (y) to continue");
                keepGoing = Console.ReadLine().ToLower();

            }
        }
    }
}
