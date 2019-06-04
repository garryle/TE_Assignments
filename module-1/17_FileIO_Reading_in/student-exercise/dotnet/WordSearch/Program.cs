using System;
using System.IO;
using System.Collections.Generic;

//

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Ask the user for the search string
            Console.WriteLine("Please enter the string you'd like to search for.");
            string inputString = Console.ReadLine();

            //2. Ask the user for the file path
            Console.WriteLine("Please enter the file path.");
            string filePath = Console.ReadLine();

            //3. Open the file
            string fullPath = Path.Combine(filePath);

            //Prompt user for y/n for case sensitive
            Console.WriteLine("Would you like your search to be case sensitive? (Y)es or (N)o");
            string caseInput = Console.ReadLine();

            //4. Loop through each line in the file
            try
            {
                //Open the text file using stream reader.
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    int lineNumber = 1;


                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (caseInput == "Y")
                        {
                            if (line.Contains(inputString))
                            {
                                Console.WriteLine(lineNumber + ".) " + line);
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            string stringLowerCase = line.ToLower();
                            string inputStringLowerCase = inputString.ToLower();
                            if (stringLowerCase.Contains(inputStringLowerCase))
                            {
                                Console.WriteLine(lineNumber + ".) " + line);
                                Console.ReadLine();
                            }
                        }
                        //5. If the line contains the search string, print it out along with its line number
                        lineNumber++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The File could not be read:");
                Console.WriteLine(e.Message);
            }

           
        }
    }
}
