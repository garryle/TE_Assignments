﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CompileItCLI
{
    public class Suicide
    {
        public void SuicideScreen()
        {
            var rando = new Random();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            List<string> reaper = new List<string>() {
"|                  ...                                |",
"|                ;::::;                               |",
"|              ;::::; :;                              |",
"|            ;:::::'   :;                             |",
"|           ;:::::; \\  /;.                            |",
"|          ,:::::'  0  0 ;           OOO\\             |",
"|          ::::::;|     |;          OOOOO\\            |",
"|          ;:::::; |   | ;         OOOOOOOO           |",
"|         ,;::::::; \\_/ ;'         / OOOOOOO          |",
"|       ;:::::::::`. ,,,;.        /  / DOOOOOO        |",
"|     .';:::::::::::::::::;,     /  /     DOOOO       |",
"|    ,::::::;::::::;;;;::::;,   /  /        DOOO      |",
"|   ;`::::::`'::::::;;;::::: ,#/  /          DOOO     |",
"|   ::`:::::::`;:::::::: ;::::# /              DOO    |",
"|   `:`:::::::`;:::::: ;::::::#/               DOO    |",
"|    :::`:::::::`;; ;:::::::::##                OO    |",
"|    ::::`:::::::`;::::::::;:::#                OO    |",
"|    `:::::`::::::::::::;'`:;::#                O     |",
"|     `:::::`::::::::;' /  / `:#                      |",
"|      ::::::`:::::;'  /  /   `#                      |"};

            for (int j = 1; j <= 5; j++)
            {
                for (int i = 1; i < 63; i += 2)
                {
                    Console.Clear();
                    for (int g = 0; g < j; g++)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    Console.ForegroundColor = (ConsoleColor)rando.Next(1, 16);
                    foreach (var item in reaper)
                    {
                        Console.Write(" ".PadLeft(i));
                        Console.WriteLine(item);
                    }
                    Thread.Sleep(100 / j);
                }
            }
            Console.ResetColor();
            Console.Write("\n\t");
            switch (rando.Next(1, 9))
            {
                case 1:
                    Console.WriteLine("Don't do drugs kids!");
                    break;
                case 2:
                    Console.WriteLine("Stay in School!");
                    break;
                case 3:
                    Console.WriteLine("You took the easy way out...");
                    break;
                case 4:
                    Console.WriteLine("You quit &*$&#%@^!!!");
                    break;
                case 5:
                    Console.WriteLine("GAME OVER");
                    break;
                case 6:
                    Console.WriteLine("You died of DYSENTERY!");
                    break;
                case 7:
                    Console.WriteLine("Who let the dogs out?");
                    break;
                case 8:
                    Console.WriteLine("Has anyone really been far even as decided to use even go want to do look more like?");
                    break;
            }
            Console.WriteLine("\nPress enter to continue.");
            string check = Console.ReadLine();
            if (check == "diabeetus")
            {
                Utility.PlaySound("Diabeetus.wav");
            }
            else
            {
                
            }
        }
    }
}
