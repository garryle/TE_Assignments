using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    class Deck
    {
        /// <summary>
        /// save the numbe of cards
        /// </summary>
        private static int numCards = 52; 

        /// <summary>
        /// internal storage for the cards
        /// </summary>
        private List<Card> Cards { get; set; } = new List<Card>();

        public bool IsEmpty
        {
            get
            {
                return Cards.Count == 0; 
            }
        }

        public int NumCardsLeft
        {
            get
            {
                return Cards.Count;
            }
        }


        /// <summary>
        /// Create a new deck of cards, unshuffled
        /// </summary>
        public Deck()
        {
            string[] suits = { "Spades", "Hearts", "Clubs", "Diamonds" };
            //for each suit
            foreach (string suit in suits)
            {
                //for 1 to 13 
                for (int i = 1; i <= 13; i++)
                {
                    //add the card
                    Card newCard = new Card(i, suit);
                    Cards.Add(newCard);
                }
            }
        }

        public Deck(bool shuffleTheDeck)
        {
            string[] suits = { "Spades", "Hearts", "Clubs", "Diamonds" };
            //for each suit
            foreach (string suit in suits)
            {
                //for 1 to 13 
                for (int i = 1; i <= 13; i++)
                {
                    //add the card
                    Card newCard = new Card(i, suit);
                    Cards.Add(newCard);
                }
            }

            if (shuffleTheDeck)
                Shuffle(); 
        }

        public void Shuffle(int numTimes)
        {
            for (int i =0; i<numTimes; i++)
            {
                Shuffle(); 
            }
        }

        /// <summary>
        /// Shuffle our deck of cards by bridge shuffling
        /// </summary>
        public void Shuffle()
        {
            Random rand = new Random();
            
            //divide the deck into two halves
            List<Card> leftSide = new List<Card>(Cards.GetRange(0,26));
            List<Card> rightSide = new List<Card>(Cards.GetRange(26,26) );

            //empty our deck
            Cards.Clear();

            //drop a random number between 1-3 cards from left side then right side
            //until you are out of cards
            while (leftSide.Count>0 || rightSide.Count>0)
            {
                int numCardsToDrop = rand.Next(4);

                //let's make sure we dont try to drop more cards than we have
                if (numCardsToDrop > leftSide.Count)
                {
                    numCardsToDrop = leftSide.Count;
                }
                Cards.AddRange( leftSide.GetRange(0, numCardsToDrop));
                leftSide.RemoveRange(0, numCardsToDrop);

                numCardsToDrop = rand.Next(4);
                //let's make sure we dont try to drop more cards than we have
                if (numCardsToDrop > rightSide.Count)
                {
                    numCardsToDrop = rightSide.Count;
                }
                Cards.AddRange(rightSide.GetRange(0, numCardsToDrop));
                rightSide.RemoveRange(0, numCardsToDrop);

            }

        }

       public override string ToString()
        {
            string strRet = "";

            foreach (Card c in Cards)
            {
                strRet += c.ToString() + "\n";
            }

            return strRet; 
        }

        /// <summary>
        /// Remove a single card from the top of the deck
        /// </summary>
        /// <returns>the top card or null if empty</returns>
        public Card DealOne()
        {
            Card result = null;

            //make sure the deck isn't empty
            if (Cards.Count > 0)
            {

                //retrive the first card from the list and set result to it
                result = Cards[0];

                //remove the card from the deck
                Cards.RemoveAt(0);
            }

            return result; 
        }       

    }
}
