using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassCode
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many items do you have?");
            string strNumItems = Console.ReadLine();

            int numItems = int.Parse(strNumItems);

            for (int i = 0; i < numItems; i++)
            {

                //whatever teh current price is, we want to give a 20% discount
                Console.WriteLine("What is the current price of item number "+ (i+1) +"?");
                string strCurrentPrice = Console.ReadLine();
                double currentPrice = double.Parse(strCurrentPrice);

                currentPrice = currentPrice * .8;

                //4.824 become 482.4
                currentPrice = currentPrice * 100;

                //482.4 become 482
                currentPrice = (int)currentPrice;

                //482 become 4.82
                currentPrice = currentPrice / 100;

                Console.WriteLine("Your discounted price is $" + currentPrice);

                Console.WriteLine("You saved " + currentPrice * .2);
            }

            Console.ReadLine();
        }
    }
}
