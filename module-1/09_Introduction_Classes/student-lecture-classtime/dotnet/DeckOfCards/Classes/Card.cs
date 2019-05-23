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

        public bool IsFaceUp { get; private set; }

        /// <summary>
        /// Constructor to create a new card face down
        /// </summary>
        /// <param name="value"> the numeric value of the card 11 for jack</param>
        /// <param name="suit">Hearts, Diamonds, Spades, Clubs</param>
        public Card (int value, string suit)
        {
            Value = value;
            Suit = suit;
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
            if (IsFaceUp)
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
                cardStr += " of " + Suit; 
            }
            return cardStr;
        }
    }
}
