﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using CompileIt;
using System.Runtime.Serialization.Formatters.Binary;
using CompileItDiceGame.Models;
using System.Xml.Serialization;

namespace CompileItCLI
{
    public class CompileItCLI
    {
        private ICompileItGame _game = null;

        private List<string> _players = new List<string>();
        private string _playerFileName = "CompileItPlayerList.dat";

        public CompileItCLI(ICompileItGame game)
        {
            _game = game;

            Utility.PlaySound("trumpet.wav");

            DisplaySplashScreen();
        }

        public void MainMenu()
        {
            bool quitGame = false;
            LoadPlayers();  //Load players at startup.
            while (!quitGame)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1) Player Management");
                Console.WriteLine("2) Leader Board");
                Console.WriteLine("3) Start Game");
                Console.WriteLine("4) Change Font");
                Console.WriteLine("5) Quit");
                Console.WriteLine();

                int selection = CLIHelper.GetSingleInteger("Select an option...", 1, 5);

                if (selection == 1)
                {
                    PlayerMenu();
                }
                else if (selection == 2)
                {
                    DisplayLeaderBoard();
                }
                else if (selection == 3)
                {
                    PlayGame();
                }
                else if (selection == 4)
                {
                    FontMenu();
                }
                else if (selection == 5)
                {
                    quitGame = true;
                }

            }
        }

        private void LoadPlayers()
        {
            //Load players from a file at startup.
            try
            {
                using (Stream stream = File.Open(_playerFileName, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    _players = (List<string>)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
                //First time through, we don't have a file.  This is ok.
            }

        }

        private void SavePlayers()
        {
            try
            {
                using (Stream stream = File.Open(_playerFileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, _players);
                }
            }
            catch (IOException)
            {
            }

        }


        public void DisplaySplashScreen()
        {
            Random rnd = new Random();
            List<List<char[]>> bannerData = new List<List<char[]>>();
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            string[] devlopers = new string[7]
                {   "Team 1: Zachary Hall, Terri Ulloa",
                    "Team 2: Patrick Reddy, Joe Knutson",
                    "Team 3: Brain Pleshek, Mitchell Morrison",
                    "Team 4: John Wunderle, Ben Loper",
                    "Team 5: Mike Wolford, Garrick Kreitzer",
                    "Team 6: Adam Smith, Josh Molczyk",
                    "Team 7: Thomas Martinez, William Terlep"    };

            string fullFileName = $@"{Environment.CurrentDirectory}\..\..\..\..\SplashData.txt";


            using (StreamReader sr = new StreamReader(fullFileName))
            {
                while (!sr.EndOfStream)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        List<char[]> foo = new List<char[]>();
                        for (int j = 0; j < 12; j++)
                        {
                            char[] screenLine = new char[86];
                            for (int k = 0; k < screenLine.Length; k++)
                            {
                                screenLine[k] = ' ';
                            }
                            screenLine = sr.ReadLine().ToCharArray();
                            foo.Add(screenLine);
                        }
                        bannerData.Add(foo);
                    }
                    for (int loop = 0; loop < 4; loop++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            rnd.Next(0, colors.Length);
                            Console.BackgroundColor = colors[rnd.Next(1, colors.Length)];
                            for (int j = 0; j < 12; j++)
                            {
                                Console.SetCursorPosition(10, 5 + j);
                                char[] screenLine = new char[86];
                                screenLine = bannerData[i][j];
                                for (int k = 0; k < screenLine.Length; k++)
                                {

                                    Console.Write(screenLine[k]);
                                }

                            }
                            System.Threading.Thread.Sleep(200);
                        }
                    }

                    int l = 0;
                    int m = 0;
                    Console.BackgroundColor = colors[0];
                    Console.SetCursorPosition(40, 18);
                    Console.Write("VERSION 0.9");
                    Console.SetCursorPosition(10, 19);
                    Console.Write("Project lead: Chris Rupp");
                    foreach (string team in devlopers)
                    {
                        Console.SetCursorPosition(21 + l, 20 + m);
                        Console.Write(team);
                        l += 2;
                        m += 1;
                    }
                }
            }
            System.Threading.Thread.Sleep(2000);
        }

        public void PlayGame()
        {
            Utility.PlaySound("pool_break.wav");

            _game.RemoveAllPlayers();
            foreach(var player in _players)
            {
                _game.AddPlayer(player);
            }
            _game.Start();

            TurnMenu();
        }

        private void FontMenu()
        {
            Utility.PlaySound("scream.wav");
        }

        private void PlayerMenu()
        {
            // loop for valid input
            int playerChoice = 0;
            bool quit = false;

            while (!quit)
            {
                //display menu method
                // query user for their choice
                // choices are add player, remove player, list players, remove all players, back to main menu
                DisplayPlayerMenu();
                playerChoice = CLIHelper.GetSingleInteger("Select an option...", 1, 5);
                if (playerChoice == 1)
                {
                    string playerName = "";
                    bool nameAdded = false;
                    while (!nameAdded)
                    {
                        nameAdded = true;
                        Console.WriteLine("\nEnter Name to add.");
                        playerName = Console.ReadLine();
                        if (playerName != "")
                        {
                            foreach (string name in _players)
                            {
                                if (name == playerName)
                                {
                                    Console.WriteLine("Name is already taken, choose another.");
                                    nameAdded = false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You can't enter an empty name, choose another.");
                            nameAdded = false;
                        }

                    }
                    //we have A UNIQUE NAME.
                    _players.Add(playerName);
                    SavePlayers();

                }
                else if (playerChoice == 2)
                {
                    int holdIndex = -1;
                    string playerName = "";
                    Console.WriteLine("\nEnter Name to remove");
                    playerName = Console.ReadLine();

                    for (int i = 0; i < _players.Count; i++)
                    {
                        //Check to see if player exists.
                        if (_players[i] == playerName)
                        {
                            holdIndex = i;
                        }
                    }
                    if (holdIndex != -1)
                    {
                        _players.Remove(playerName);
                    }
                    else
                    {
                        Console.WriteLine("This is not a player name.  Nothing to remove.  Hit any key to continue.");
                        Console.ReadKey();
                    }
                }
                else if (playerChoice == 3)
                {
                    int i = 1;
                    Console.WriteLine("\n\nList of Current Players in the game:");
                    foreach (string player in _players)
                    {
                        Console.WriteLine($"Player {i}: {player}");
                        i++;
                    }
                    Console.WriteLine("\nHit any key to continue.");
                    Console.ReadKey();
                }
                else if (playerChoice == 4)
                {
                    _players.Clear();
                    Console.WriteLine("\n\nAll players have been removed.  Hit any key to continue.");
                    Console.ReadKey();
                }
                else if (playerChoice == 5)
                {
                    quit = true;
                }
            }
        }

        private void DisplayPlayerMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("1) Add Player");
            Console.WriteLine("2) Remove Player");
            Console.WriteLine("3) List Players");
            Console.WriteLine("4) Remove All Players");
            Console.WriteLine("5) Back To Main Menu");
            Console.WriteLine();
        }

        private void DisplayLeaderBoard()
        {
            Console.Clear();

            string currentDir = Environment.CurrentDirectory + @"\..\..\..\..";

            string fileName = "LeaderBoard.xml";

            string fullPath = Path.Combine(currentDir, fileName);

            List<PlayerScore> playerScores = new List<PlayerScore>();

            List<PlayerScore> leaderBoard = new List<PlayerScore>();

            XmlSerializer xmlSerializer = new XmlSerializer(playerScores.GetType());

            int highestScore = 0;

            // If game win file exists load here
            if (File.Exists(fullPath))
            {
                // Reads the xml and adds the objects to the pastPlayers list
                using (StreamReader strReader = new StreamReader(fullPath))
                {
                    playerScores = (List<PlayerScore>)xmlSerializer.Deserialize(strReader);
                }
            }

            if (playerScores.Count == 0)
            {
                Utility.PlaySound("SadTrombone.wav");
                Console.WriteLine("\n\n         Guess what..." +
                    " No one has played yet\n");

                Console.WriteLine(@"
            ░░░░░░░░░░░░░░▄▄▄▄▄▄▄▄▄▄▄▄░░░░░░░░░░░░░░
            ░░░░░░░░░░░░▄████████████████▄░░░░░░░░░░
            ░░░░░░░░░░▄██▀░░░░░░░▀▀████████▄░░░░░░░░
            ░░░░░░░░░▄█▀░░░░░░░░░░░░░▀▀██████▄░░░░░░
            ░░░░░░░░░███▄░░░░░░░░░░░░░░░▀██████░░░░░
            ░░░░░░░░▄░░▀▀█░░░░░░░░░░░░░░░░██████░░░░
            ░░░░░░░█▄██▀▄░░░░░▄███▄▄░░░░░░███████░░░
            ░░░░░░▄▀▀▀██▀░░░░░▄▄▄░░▀█░░░░█████████░░
            ░░░░░▄▀░░░░▄▀░▄░░█▄██▀▄░░░░░██████████░░
            ░░░░░█░░░░▀░░░█░░░▀▀▀▀▀░░░░░██████████▄░
            ░░░░░░░▄█▄░░░░░▄░░░░░░░░░░░░██████████▀░
            ░░░░░░█▀░░░░▀▀░░░░░░░░░░░░░███▀███████░░
            ░░░▄▄░▀░▄░░░░░░░░░░░░░░░░░░▀░░░██████░░░
            ██████░░█▄█▀░▄░░██░░░░░░░░░░░█▄█████▀░░░
            ██████░░░▀████▀░▀░░░░░░░░░░░▄▀█████████▄
            ██████░░░░░░░░░░░░░░░░░░░░▀▄████████████
            ██████░░▄░░░░░░░░░░░░░▄░░░██████████████
            ██████░░░░░░░░░░░░░▄█▀░░▄███████████████
            ███████▄▄░░░░░░░░░▀░░░▄▀▄███████████████");

            }
            else
            {
                Utility.PlaySound("TaDa.wav");

                for (int i = 0; i < playerScores.Count; i++)
                {
                    if (playerScores[i].NumOfWins > highestScore)
                    {
                        leaderBoard.Insert(0, playerScores[i]);
                        highestScore = playerScores[i].NumOfWins;
                    }
                    else
                    {
                        bool isHigher = false;

                        while (!isHigher)
                        {
                            for (int j = 0; j < leaderBoard.Count; j++)
                            {
                                if (playerScores[i].NumOfWins > leaderBoard[j].NumOfWins)
                                {
                                    leaderBoard.Insert(j, playerScores[i]);
                                    j = leaderBoard.Count;
                                    isHigher = true;
                                }
                                else if (playerScores[i].NumOfWins == leaderBoard[j].NumOfWins)
                                {
                                    leaderBoard.Insert(j, playerScores[i]);
                                    j = leaderBoard.Count;
                                    isHigher = true;
                                }
                            }

                            if (!isHigher)
                            {
                                leaderBoard.Add(playerScores[i]);
                                isHigher = true;
                            }
                        }

                    }
                }

                int rank = 1;
                Console.WriteLine(@"
 _                   _             ____                      _ 
| |    ___  __ _  __| | ___ _ __  | __ )  ___   __ _ _ __ __| |
| |   / _ \/ _` |/ _` |/ _ \ '__| |  _ \ / _ \ / _` | '__/ _` |
| |__|  __/ (_| | (_| |  __/ |    | |_) | (_) | (_| | | | (_| |
|_____\___|\__,_|\__,_|\___|_|    |____/ \___/ \__,_|_|  \__,_| 
");
                Console.WriteLine("\n Rank".PadRight(15) + "Player".PadRight(15) + "Number of wins\n");

                foreach (PlayerScore player in leaderBoard)
                {
                    Console.WriteLine($" {rank}".PadRight(15) + $"{player.PlayerName}".PadRight(15) + $"{player.NumOfWins}\n");
                    rank++;
                }
            }
            Console.WriteLine("\n\nPress any key to return to the main menu...");
            Console.ReadKey();
        }

        private void DisplaySuicideScreen()
        {
            Utility.PlaySound("taps.wav");

            Suicide quitGame = new Suicide();
            quitGame.SuicideScreen();
        }

        private void TurnMenu()
        {
            bool quit = false;
            while (!quit)
            {
                try
                {
                    Console.Clear();

                    if (_game.HasWinner)
                    {
                        Utility.PlaySound("applause.wav");
                        _game.SaveWinner(_game.CurrentPlayerName);
                        Console.Clear();
                        Console.WriteLine("The winner is " + _game.CurrentPlayerName);
                        Console.ReadKey();
                        quit = true;
                    }
                    else
                    {
                        DisplayPlayerStatus();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine("1) Roll");
                        Console.WriteLine("2) End Turn");
                        Console.WriteLine("3) Score Board");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("4) Suicide");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();

                        int selection = CLIHelper.GetSingleInteger("Select an option...", 1, 4);

                        if (selection == 1)
                        {
                            Utility.PlaySound("thunder.wav");
                            RollDice();
                        }
                        else if (selection == 2)
                        {
                            Utility.PlaySound("skids.wav");
                            _game.PassTurn();
                        }
                        else if (selection == 3)
                        {
                            DisplayScoreBoard();
                        }
                        else if (selection == 4)
                        {
                            DisplaySuicideScreen();
                            quit = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
        }

        private void RollDice()
        {
            ITurnStatus status = _game.RollDice();

            if (status.TurnErrors >= 3)
            {
                Utility.PlaySound("whah_whah.wav");
                Console.Clear();
                Console.WriteLine("You busted!\n\nPress any key to continue...");
                Console.ReadKey();
                _game.PassTurn();
            }
        }

        private void DisplayScoreBoard()
        {
            var status = _game.PlayersStatus;

            Console.Clear();
            Console.WriteLine("SCORE BOARD");
            Console.WriteLine();

            Utility.PlaySound("LOZ_Fanfare.wav");

            try
            {
                for (int i = 0; i < status.Count; i++)
                {
                    var listedPlayer = status[i];

                    if (!(listedPlayer.Name).Equals(_game.CurrentPlayerName))
                    {
                        Console.Write((listedPlayer.Name + " ").PadRight(15, '-'));
                        Console.Write(((listedPlayer.TotalSuccesses).ToString().PadLeft(3) + " Successes ").PadRight(15, '-'));
                        Console.WriteLine((listedPlayer.RoundCount).ToString().PadLeft(3) + " Rounds Completed");
                    }
                    else
                    {
                        Console.Write(("You ").PadRight(15, '-'));
                        Console.Write(((listedPlayer.TotalSuccesses).ToString().PadLeft(3) + " Successes ").PadRight(15, '-'));
                        Console.WriteLine((listedPlayer.RoundCount).ToString().PadLeft(3) + " Rounds Completed");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Oops... the Score Board freaked out and exploded. Please contact tech support.");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DisplayPlayerStatus()
        {
            // Add colors for different players
            SetColor();

            // Undergo Beautification
            var status = _game.CurrentPlayerStatus;
            string header = "*";
            string player = $"Player: {_game.CurrentPlayerName}";
            string round = $"Round: {status.RoundCount} {(_game.IsLastRound ? " Last Turn" : "")}";
            string totalSuccesses = $"Total Successes: {status.TotalSuccesses}";
            string turnErrors = $"Turn Errors: {status.TurnErrors}";
            string turnSuccesses = $"Turn Successes: {status.TurnSuccesses}";
            string turnWarnings = $"Turn Warnings: {status.TurnWarnings}";
            string odds = $"Odds: {status.Odds.ToString("N2")}";
            string remainingDie = $"Remaining Dice: {status.RemainingDice.Count}";

            Console.WriteLine(header.PadLeft(30, '*'));
            Console.WriteLine($"{header.PadRight(29, ' ').PadLeft(26, ' ')}*");
            Console.WriteLine($"*{player.PadLeft(20, ' ').PadRight(28, ' ')}*");
            Console.WriteLine($"*{round.PadLeft(21, ' ').PadRight(28, ' ')}*");
            Console.WriteLine($"*{totalSuccesses.PadLeft(20, ' ').PadRight(28, ' ')}*");
            Console.WriteLine($"{header.PadRight(29, ' ').PadLeft(26, ' ')}*");
            Console.WriteLine(header.PadLeft(30, '*'));

            ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{header.PadRight(29, ' ').PadLeft(26, ' ')}*");
            Console.WriteLine($"*{turnErrors.PadLeft(20, ' ').PadRight(28, ' ')}*");
            Console.WriteLine($"*{turnSuccesses.PadLeft(20, ' ').PadRight(28, ' ')}*");
            Console.WriteLine($"*{turnWarnings.PadLeft(20, ' ').PadRight(28, ' ')}*");
            Console.WriteLine($"{header.PadRight(29, ' ').PadLeft(26, ' ')}*");
            Console.WriteLine(header.PadLeft(30, '*'));

            Console.WriteLine($"{header.PadRight(29, ' ').PadLeft(26, ' ')}*");

            // Add information about dice in cup
            Console.WriteLine($"*{odds.PadLeft(23, ' ').PadRight(28, ' ')}*");

            //return total amount of die remaining in the cup
            Console.WriteLine($"*{remainingDie.PadLeft(21, ' ').PadRight(28, ' ')}*");

            //color of the remaining die in the cup and quantity
            int greenCounter = 0;
            int redCounter = 0;
            int yellowCounter = 0;
            foreach (var die in status.RemainingDice)
            {
                if (die.DieType == Die.GreenDie)
                {
                    greenCounter += 1;
                }
                else if (die.DieType == Die.RedDie)
                {
                    redCounter += 1;
                }
                else if (die.DieType == Die.YellowDie)
                {
                    yellowCounter += 1;
                }
            }

            string greenDie = $"{Die.GreenDie}: {greenCounter} ";
            string yellowDie = $"{Die.YellowDie}: {yellowCounter} ";
            string redDie = $"{Die.RedDie}: {redCounter}";

            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(greenDie.PadLeft(10, ' '));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(yellowDie);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(redDie.PadRight(8, ' '));
            ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("*");
            Console.WriteLine();
            Console.WriteLine($"{header.PadRight(29, ' ').PadLeft(26, ' ')}*");
            Console.WriteLine(header.PadLeft(30, '*'));
            Console.WriteLine();

            ResetColor();
        }

        public Dictionary<int, ConsoleColor> ColorDictionary = new Dictionary<int, ConsoleColor>()
                {
                    {0, ConsoleColor.Blue},
                    {1, ConsoleColor.DarkMagenta},
                    {2, ConsoleColor.Red},
                    {3, ConsoleColor.Yellow},
                    {4, ConsoleColor.White},
                    {5, ConsoleColor.Cyan}
                };
        private void SetColor()
        {
            Console.ForegroundColor = ColorDictionary[_players.IndexOf(_game.CurrentPlayerName)];
        }

        private void ResetColor()
        {
            Console.ResetColor();
        }

    }
}








