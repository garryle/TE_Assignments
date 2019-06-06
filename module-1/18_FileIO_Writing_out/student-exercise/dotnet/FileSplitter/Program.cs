using System;
using System.IO;

namespace FileSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get Directory of file
            string fullPath = Path.Combine($@"{Environment.CurrentDirectory}\..\..\..", "input.txt");
           
            //Prompts user for number of lines per file
            Console.WriteLine("How many lines of test (max) should there be in the split files? ");
            string userInput = Console.ReadLine();
            int lineCount = int.Parse(userInput);

            //Reads file
            using (StreamReader sr = new StreamReader(fullPath))
            {
                int fileNumber = 1;
                while (!sr.EndOfStream)
                {
                    //Designates path where new files will go
                    string outputPath = Path.Combine($@"{Environment.CurrentDirectory}\..\..\..", $"input-{fileNumber}.txt");

                    using (StreamWriter sw = new StreamWriter(outputPath))
                    {
                        for (int i = 0; !sr.EndOfStream && i < lineCount; i++)
                        {
                            sw.WriteLine(sr.ReadLine());
                        }
                    }
                    //counts numbers
                    fileNumber++;
                }
            }
        }
    }
}
