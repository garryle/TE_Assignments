using DeckOfCards.Classes;
using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a deck 
            Deck deck = new Deck();

            //print it
           // Console.WriteLine(deck.ToString());

            //shuffle it
            deck.Shuffle(3);

            //i need this line so the console will write the symbols
            Console.OutputEncoding = System.Text.Encoding.UTF8; 

            //print it again
            Console.WriteLine(deck.ToString());

            Console.WriteLine("********************");

            for(int i = 0; i<55; i++)
            {
                Card dealt = deck.DealOne();
                Console.WriteLine("You just got dealt " + (dealt ==null? "no card": dealt.ToString())); 
            }
            Console.WriteLine("after dealing 50");
            Console.WriteLine("Number of cards left in the deck" + deck.NumCardsLeft);

            Console.WriteLine($"Is the deck empty? {deck.IsEmpty}");

            Console.Read(); 
        }
    }
}
