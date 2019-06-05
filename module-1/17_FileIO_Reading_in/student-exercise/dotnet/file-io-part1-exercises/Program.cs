using System;
using System.Collections.Generic;
using System.IO;

namespace file_io_part1_exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Question> questionList = new List<Question>();
            int correctAnwers = 0;
            Question.PullQuestions(questionList);

            for (int i = 0; i < questionList.Count; ++i)
            {
                //Writes the Questions
                Console.WriteLine(questionList[i].TheQuestion);
                Console.WriteLine();

                string[] questions = questionList[i].TheAnswer;
                
                //Writes the available answers
                for (int j = 0; j < questions.Length; ++j)
                {
                    Console.WriteLine(1 + j + ". " + questions[j]);
                }

                //Reads user input
                Console.WriteLine("Your Answer: ");
                int answer = int.Parse(Console.ReadLine());

                //Compares the quiz answers with user input and counts
                if (answer == questionList[i].TheRightAnswer)
                {
                    correctAnwers++;
                    Console.WriteLine("Right!");
                }
                else
                {
                    Console.WriteLine("Wrong!");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Correct Answers: " + correctAnwers);
            Console.ReadLine();
        }
    }
}
