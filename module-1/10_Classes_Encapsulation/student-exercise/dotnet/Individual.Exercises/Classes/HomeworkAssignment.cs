using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class HomeworkAssignment
    {
        public int TotalMarks { get; set; } 
        public int PossibleMarks { get; }
        public string SubmitterName { get; }

        public string LetterGrade
        {
            get
            {
                if (TotalMarks / (double)PossibleMarks >= .90)
                {
                    return "A";
                }
                else if (TotalMarks / (double)PossibleMarks >= .80)
                {
                    return "B";
                }
                else if (TotalMarks / (double)PossibleMarks >= .70)
                {
                    return "C";
                }
                else if (TotalMarks / (double)PossibleMarks >= .60)
                {
                    return "D";
                }
                else
                {
                    return "F";
                }
            }

        }

        //Constructor
        public HomeworkAssignment(int possibleMarks, string submitterName)
        {
            PossibleMarks = possibleMarks;
            SubmitterName = submitterName;
        }



    }
}
