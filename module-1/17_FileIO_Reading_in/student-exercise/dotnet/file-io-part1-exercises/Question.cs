using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace file_io_part1_exercises
{
    public class Question
    {
        public string TheQuestion { get; private set; }
        public string[] TheAnswer { get; private set; }
        public int TheRightAnswer { get; private set; }

        public Question(string question, string[] answers, int answer)
        {
            TheQuestion = question;
            TheAnswer = answers;
            TheRightAnswer = answer;
        }

        public static void PullQuestions(List<Question> questionList)
        {
            string fileName = "sample-quiz-file.txt";
            string directory = Directory.GetCurrentDirectory();
            string fullPath = Path.Combine(directory, fileName);

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] substrings = line.Split('|');
                        string[] stringQuestion = new string[4];
                        int numberOfCorrectAnswers = 0;

                        for (int i = 1; i < substrings.Length; ++i)
                        {
                            if (substrings[i].Contains("*"))
                            {
                                substrings[i] = substrings[i].Remove(substrings[i].IndexOf("*"));
                                numberOfCorrectAnswers = i;
                            }

                            stringQuestion[i - 1] = substrings[i];
                        }

                        questionList.Add(new Question(substrings[0], stringQuestion, numberOfCorrectAnswers));
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
