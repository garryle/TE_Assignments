using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballCoachApp
{
    class Program
    {
        static void Main(string[] args)
        {


            string binary = ConvertIntToBinary(8);

            //First let's get the total number of players
            Console.WriteLine("How many players are on your team?");
            string strTotalPlayers = Console.ReadLine();
            int totalPlayers = int.Parse(strTotalPlayers);

            //creating arrays to hold the player data
            string[] playerNameArray = new string[totalPlayers];
            double[] battingAverageArray = new double[totalPlayers];

            //make a loop to get the information from the user for each player
            for (int i = 0; i < totalPlayers; i++)
            {
                Console.WriteLine("What is player " + (i + 1) + "'s name?");
                playerNameArray[i] = Console.ReadLine();
                Console.WriteLine("How many times has " + playerNameArray[i] + " been at bat?");
                string strNumAtBats = Console.ReadLine();
                int numAtBats = int.Parse(strNumAtBats);
                Console.WriteLine("How many hits does " + playerNameArray[i] + " have?");
                string strNumHits = Console.ReadLine();
                int numHits = int.Parse(strNumHits);
                battingAverageArray[i] = ((double)numHits) / numAtBats;
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Here is your team batting info: ");
            int maxAverageIndex = 0;
            for (int i = 0; i < totalPlayers; i++)
            {
                double battingAverageToPrint = PrettifyBattingAverage(battingAverageArray[i]);
                Console.WriteLine(playerNameArray[i] + " " + battingAverageToPrint);
                if (battingAverageArray[i] > battingAverageArray[maxAverageIndex])
                {
                    maxAverageIndex = i;
                }
            }
            Console.WriteLine("Your best batter is " + playerNameArray[maxAverageIndex]);
            Console.Read();
        }

        public static double PrettifyBattingAverage(double battingAverage)
        {
            //.13333333d
            //first let's make it 133.33333
            battingAverage = battingAverage * 1000;
            //let's make it 133
            battingAverage = (int)battingAverage;
            //make it .133
            battingAverage = battingAverage / 1000;

            return battingAverage; 
        }

        public static string ConvertIntToBinary(int base10)
        {
            string binary = "";

            while (base10 > 0)
            {
                binary = (base10 % 2) + binary;
                base10 = base10 / 2;
            }
            return binary;
        }
    }
}
