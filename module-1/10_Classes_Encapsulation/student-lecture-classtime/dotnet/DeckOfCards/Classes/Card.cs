using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    public class Card
    {
        /// <summary>
        /// The numeric value of the card. This will be 11 for Jacks, 12 for Queen, 13 for king, 1 for ace
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// The card suit
        /// </summary>
        public string Suit { get; }

        /// <summary>
        /// Derived property based on the Suit
        /// </summary>
        public string Color
        {
            get
            {
                if (Suit == "Hearts" || Suit == "Diamonds")
                {
                    return "Red";
                }
                else
                {
                    return "Black";
                }
            }
        }

        public string FaceValue
        {
            get
            {
                return faceValues[Value]; 
            }
        }

        static Dictionary<int, string> faceValues = new Dictionary<int, string>()
                {
                    {1, "Ace" },
                    {2, "Two" },
                    {3, "Three" },
                    {4, "Four" },
                    {5, "Five" },
                    {6, "Six" },
                    {7, "Seven" },
                    {8, "Eight" },
                    {9, "Nine" },
                    {10, "Ten" },
                    {11, "Jack" },
                    {12, "Queen" },
                    {13, "King" }
                };

        static Dictionary<string, char> suitSymbols = new Dictionary<string, char>()
        {
            {"Spades", '\u2660'},
            {"Diamonds", '\u2666'},
            {"Clubs", '\u2663'},
            {"Hearts", '\u2665'}
        };

        public bool IsFaceUp { get; private set; }

        /// <summary>
        /// Constructor to create a new card face down
        /// </summary>
        /// <param name="value"> the numeric value of the card 11 for jack</param>
        /// <param name="suit">Hearts, Diamonds, Spades, Clubs</param>
        public Card (int value, string suit)
        {
            if (value >= 1 && value <= 13)
            {
                Value = value;
            }
            else
            {
                Value = 1;
            }

            if (suitSymbols.ContainsKey(suit))
            {
                Suit = suit;
            }
            else
            {
                Suit = "Hearts";
            }
            IsFaceUp = false; 
        }

        /// <summary>
        /// Constructor that lets the user specify value, suit and is face up
        /// </summary>
        /// <param name="value">numeric value of the card 11 for jacks</param>
        /// <param name="suit">Hearts, Diamonds, Spades, Clubs</param>
        /// <param name="isFaceUp">true for face up, false for face down</param>
        public Card(int value, string suit, bool isFaceUp)
        {
            Value = value;
            Suit = suit;
            IsFaceUp = isFaceUp;
        }

        /// <summary>
        /// Toggle faceup to face down and face down to face up
        /// </summary>
        public void Flip()
        {
            //Console.WriteLine("in flip with no parameter");
            IsFaceUp = !IsFaceUp;
         
        }

        public void Flip(int numberOfTimes)
        {
            //Console.WriteLine("in flip with parameter");
            for (int i=0; i<numberOfTimes;i++)
            {
                Flip(); 
            }
        }

        public override string ToString()
        {
            string cardStr = "IDK";
            //if (IsFaceUp)
            {
                cardStr = "";

                if (Value > 1 && Value <= 10)
                {
                    cardStr += Value;
                }
                else
                {
                    switch (Value)
                    {
                        case 11:
                            cardStr += "Jack";
                            break;
                        case 12:
                            cardStr += "Queen";
                            break;
                        case 13:
                            cardStr += "King";
                            break;
                        case 1:
                            cardStr += "Ace";
                            break;
                    }

                }
                cardStr += " of " + suitSymbols[Suit]; 
            }
            return cardStr;
        }
    }
}
