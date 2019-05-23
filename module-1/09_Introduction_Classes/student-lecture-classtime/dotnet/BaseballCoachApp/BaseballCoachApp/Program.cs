using BaseballCoachApp.Classes;
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
            
            //create list to hold the player data
            List<BaseballPlayer> teamList = new List<BaseballPlayer>();
            BaseballPlayer thisPlayer; 

            //make a loop to get the information from the user for each player
            string done = "NO WAY"; 
            while (done.ToLower() != "y")
            {
                string name = "";
                double battingAverage = 0; 
                
                Console.WriteLine("What is the player's name?");
                name = Console.ReadLine();
                Console.WriteLine("How many times has " + name + " been at bat?");
                string strNumAtBats = Console.ReadLine();
                int numAtBats = int.Parse(strNumAtBats);
                Console.WriteLine("How many hits does " + name + " have?");
                string strNumHits = Console.ReadLine();
                int numHits = int.Parse(strNumHits);
                battingAverage = ((double)numHits) / numAtBats;

                thisPlayer = new BaseballPlayer(name, "", battingAverage);
                teamList.Add(thisPlayer);
                
                Console.WriteLine("Are you finished? Type y to end");
                done = Console.ReadLine(); 
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Here is your team batting info: ");
            double maxAverage = 0;
            foreach (BaseballPlayer player in teamList)
            {
                //Console.WriteLine($"{player.FirstName} average is {player.Average}");
                Console.WriteLine(player.ToString()); 
                if (player.Average > maxAverage)
                {
                    maxAverage = player.Average;
                }
            }

            foreach (BaseballPlayer player in teamList)
            {               
                if (player.Average >= maxAverage)
                {
                    Console.WriteLine(player.FirstName + " has the best average at " + player.Average);
                }
            }

           
            //for (int i = 0; i < totalPlayers; i++)
            //{
            //    double battingAverageToPrint = PrettifyBattingAverage(battingAverageArray[i]);
            //    Console.WriteLine(playerNameArray[i] + " " + battingAverageToPrint);
            //    if (battingAverageArray[i] > battingAverageArray[maxAverageIndex])
            //    {
            //        maxAverageIndex = i;
            //    }
            //}
          
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

    }
}
