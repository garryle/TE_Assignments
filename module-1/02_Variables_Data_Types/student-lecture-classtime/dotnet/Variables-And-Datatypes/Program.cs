using System;

namespace Variables_And_Datatypes
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES & DATA TYPES */

            /*
		    1. Create a variable to hold an int and call it numberOfExercises.
			Then set it to 26.
		    */
            int numberOfExercises =26;


            Console.WriteLine(numberOfExercises);

            /*
            2. Create a variable to hold a double and call it half.
                Set it to 0.5.
            */

            double half = .5; 
            Console.WriteLine(half);

            /*
            3. Create a variable to hold a string and call it name.
                Set it to "TechElevator".
            */
            string name = "TechElevator";
            Console.WriteLine(name);

            /*
            4. Create a variable called seasonsOfFirefly and set it to 1.
            */

            int seasonsOfFirefly = 1;
            Console.WriteLine(seasonsOfFirefly);

            /*
            5. Create a variable called myFavoriteLanguage and set it to "C#".
            */
            string myFavoriteLanguage = "C#";
            myFavoriteLanguage = "Javascript";
            Console.WriteLine(myFavoriteLanguage);

            /*
            6. Create a variable called pi and set it to 3.1416.
            */

            //this is my comment
            const double PI = 3.1416;
            Console.WriteLine(PI);

            /*
            7. Create and set a variable that holds your name.
            */
            string myName = "Katie Dwyer";

            /*
            8. Create and set a variable that holds the number of buttons on your mouse.
            */
            int mouseButtons = 5;

            /*
            9. Create and set a variable that holds the percentage of battery left on
            your phone.
            */
            int batteryLeft = 80;

            /* EXPRESSIONS */

            /*
            10. Create an int variable that holds the difference between 121 and 27.
            */
            int diff = 121 - 27;

            /*
            11. Create a double that holds the addition of 12.3 and 32.1.
            */
            double addValue;
            addValue = 12.3 + 32.1; 
            Console.WriteLine(addValue);

            /*
            12. Create a string that holds your full name.
            */
            string fullName = "Katie Lyn Dwyer";

            /*
            13. Create a string that holds the word "Hello, " concatenated onto your
            name from above.
            */
            string message = "Hello, " + fullName;
            Console.WriteLine(message);

            /*
            14. Add a " Esquire" onto the end of your full name and save it back to
            the same variable.
            */
            fullName = fullName + " Esquire";

            /*
            15. Now do the same as exercise 14, but use the += operator.
            */
            fullName += " Esquire";
            /*
            16. Create a variable to hold "Saw" and add a 2 onto the end of it.
            */
            int version = 2; 
            string terribleMovie = "Saw";
            terribleMovie += version;

            /*
            17. Add a 0 onto the end of the variable from exercise 16.
            */

            terribleMovie += "0";

            /*
            18. What is 4.4 divided by 2.2?
            */
            double result = 4.4 / 2.2;

            /*
            19. What is 5.4 divided by 2?
            */
            double result19 = 5.4 / 2;

            /* CASTING */

            /*
            20. What is 5 divided by 2?
            */
            double result20 = 5 / 2;
            Console.WriteLine(result20);

            /*
            21. What is 5.0 divided by 2?
            */
            double result21 = 5.0 / 2;

            /*
            22. Create a variable that holds a bank balance with the value of 1234.56.
            */

            //22b
            //66.6/100   *TODO FIND EXAMPLE
            double dubResult = 66.0 / 100;
            Console.WriteLine("Double: " + dubResult);

            float floatResult = 66.0F / 100;
            Console.WriteLine("Float: " + floatResult);

            decimal decResult = 66.0M / 100;
            Console.WriteLine("Decimal: " + decResult);
            /*
            23. If I divide 5 by 2, what's my remainder?
            */

            int myRemainder = 5 % 2;

            /*
            24. Create two variables: 3 and 1,000,000,000 and multiple them together. 
                What is the result?
            */
            int three = 3;
            long billion = 1000000000;
            long result24 = three * billion;
            Console.WriteLine(result24);

            /*
            25. Create a variable that holds a boolean called doneWithExercises and
            set it to false.
            */
            bool doneWithExercises = false;
            /*
            26. Now set doneWithExercise to true.
            */
            doneWithExercises = true; 

            Console.ReadLine();
        }
    }
}
