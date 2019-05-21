using System;
using System.Collections.Generic;

namespace CollectionsLectureNotes
{
    class Program
    {
        static void Main(string[] args)
        {

            //string name = "Katie";
            //DateTime date = DateTime.Now;

            //// Composite formatting:
            //Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);
            //// String interpolation:
            //Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");

            //// Both calls produce the same output that is similar to:
            //// Hello, Mark! Today is Wednesday, it's 19:40 now.

            // LIST<T>
            //
            // Lists allow us to hold collections of data. They are declared with a type of data that they hold
            // only allowing items of that type to go inside of them.
            //
            // The syntax used for declaring a new list of type T is
            //      List<T> list = new List<T>();
            //
            //

            // Creating lists of integers
            List<int> numberList = new List<int>();
            numberList.Add(1);


            // Creating lists of strings
            List<string> strList = new List<string>();


            /////////////////


            //////////////////
            // OBJECT EQUALITY
            //////////////////

            List<int> numberListEqualTest1 = new List<int>();
            List<int> numberListEqualTest2 = new List<int>();

            Console.WriteLine("are the lists equal?" + (numberListEqualTest1 == numberListEqualTest2));
            numberListEqualTest2 = numberListEqualTest1;
            Console.WriteLine("are the lists equal after assignment?" + (numberListEqualTest1 == numberListEqualTest2));

            /////////////////
            // ADDING ITEMS
            /////////////////

            // Adding items one at a time to each list
            strList.Add("Chelsea");
            strList.Add("Erick");


            /////////////////
            // ADDING MULTIPLE ITEMS
            /////////////////

            int[] myArray = { 1, 5, 7 };
            numberList.AddRange(myArray);

            //////////////////
            // ACCESSING BY INDEX
            //////////////////
            Console.WriteLine("Number list item at index 3 is " + numberList[3]);



            ///////////////////
            // ACCESSING WITH FOR-EACH
            ///////////////////
            Console.WriteLine("Here is my numberList");
            foreach(int thing in numberList)
            {
                Console.WriteLine(thing); 
            }

            Console.WriteLine("Here is my strList");
            foreach (string value in strList)
            {
                Console.WriteLine(value);
            }

            //how many times erick is in our list
            int countErick = 0; 
            foreach (string value in strList)
            {
                if (value.ToLower().Contains("erick"))
                    countErick++; 
            }
            Console.WriteLine($"Erick is in my list {countErick} times");


            ////////////////////
            // ADDITIONAL LIST<T> METHODS
            ////////////////////
            strList.Contains("Erick");
            int index = strList.IndexOf("Erick");
            strList.Insert(0, "Bradley");
            Console.WriteLine("Here is my strList after inserting Bradley");
            foreach (string value in strList)
            {
                Console.WriteLine(value);
            }
            strList.Remove("Chelsea");
            Console.WriteLine("Here is my strList after removing Chelsea");
            foreach (string value in strList)
            {
                Console.WriteLine(value);
            }

            ////////////////////////
            // SORT and PRINT A LIST
            ////////////////////////
            strList.Add("Richie");
            strList.Add("Luna");
            strList.Add("paul");
            strList.Sort();
            Console.WriteLine("strList elements separated by a comma: ");
            Console.WriteLine(String.Join(", ", strList));
            strList.Reverse();
            Console.WriteLine("strList after reverse ");
            Console.WriteLine(String.Join(", ", strList));

            //add a lot of people
            string[] classList = { "Cody", "Bri", "Scotty", "Mark" };
            strList.AddRange(classList);

            List<string> myOtherList = new List<string>();
            myOtherList.Add("Katie");
            strList.AddRange(myOtherList);
            Console.WriteLine("strList after a bunch of stuf: ");
            Console.WriteLine(String.Join(", ", strList));

            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.

            Console.WriteLine("***FUN WITH QUEUES***");
            Queue<string> ticketMasterLine = new Queue<string>();
            ticketMasterLine.Enqueue("Katie");           
            ticketMasterLine.Enqueue("Luna");
            ticketMasterLine.Enqueue("George Foreman");

            Console.WriteLine("WHo is first in line?" + ticketMasterLine.Peek()); 

            while (ticketMasterLine.Count > 0)
            {
                string nextCustomer = ticketMasterLine.Dequeue();
                Console.WriteLine($"Selling tickets to { nextCustomer}");
            }


            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////



            // STACK <T>
            //
            // Stacks are another type of data structure that follow Last-In First-Out (LIFO).
            // With Stacks, we Push (add) and Pop (remove) items.

            Stack<string> browserStack = new Stack<string>();


            ////////////////////
            // PUSHING ITEMS TO THE STACK
            //////////////////// 

            browserStack.Push("www.gooogle.com");
            browserStack.Push("www.cnn.com");
            browserStack.Push("www.techelevator.com");
            browserStack.Push("www.cirr.com");


            ////////////////////
            // POPPING THE STACK
            ////////////////////

            while (browserStack.Count>0)
            {
                string previousPage = browserStack.Pop();
                Console.WriteLine("Previous page " + previousPage);
            }

            Console.ReadLine();

        }
    }
}
