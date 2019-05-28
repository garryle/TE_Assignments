using InheritanceLecture.Auctioneering;
using System;

namespace InheritanceLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new general auction
            Console.WriteLine("Starting a buyout auction");
            Console.WriteLine("-----------------");

            Auction buyoutAuction = new BuyoutAuction(15);

            buyoutAuction.PlaceBid(new Bid("Josh", 1));
            buyoutAuction.PlaceBid(new Bid("Fonz", 23));
            buyoutAuction.PlaceBid(new Bid("Rick Astley", 13));
            //....
            //....
            // This might go on until the auction runs out of time or hits a max # of bids

            Console.WriteLine("Starting a Reserve auction");
            Console.WriteLine("-----------------");

            Auction reserveAuction = new ReserveAuction(15);

            reserveAuction.PlaceBid(new Bid("Josh", 1));
            reserveAuction.PlaceBid(new Bid("Fonz", 23));
            reserveAuction.PlaceBid(new Bid("Rick Astley", 13));
            //....
            //....
            // This might go on until the auction runs out of time or hits a max # of bids



            Console.ReadLine();
        }
    }
}
