using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.Auctioneering
{
    /// <summary>
    /// A buyout auction sets a buyout price that if a bidder hits makes the auction end
    /// </summary>
    class BuyoutAuction : Auction
    {
        /// <summary>
        /// if a bidder hits this price, then the auction is over
        /// </summary>
        private int buyoutPrice; 

        /// <summary>
        /// constructor to set the buyout price
        /// </summary>
        /// <param name="buyoutPrice"></param>
        public BuyoutAuction(int buyoutPrice) 
        {
            this.buyoutPrice = buyoutPrice;
            Console.WriteLine("in BuyoutAuction constructor");
        }

        /// <summary>
        /// access the buyout price
        /// </summary>
        public int BuyoutPrice
        {
            get { return buyoutPrice; }
        }

        /// <summary>
        /// Places a Bid on the Auction - if the buyout is met, then the auction is over
        /// </summary>
        /// <param name="offeredBid">The bid to place.</param>
        /// <returns>True if the new bid is the current winning bid</returns>
        public override bool PlaceBid(Bid offeredBid)
        {            
            bool isNewHighBid = false;

            // Print out the bid details.
            Console.WriteLine($"Bid of {offeredBid.BidAmount} offered by {offeredBid.Bidder} in BuyoutAuction PlaceBid");

            //we will only consider the bid if buyout hasn't been reached already
            if (buyoutPrice > CurrentHighBid.BidAmount)
            {
                //if this bid is higher than the buyout
                if (offeredBid.BidAmount >= buyoutPrice)
                {
                    Bid buyoutBid = new Bid(offeredBid.Bidder, buyoutPrice);
                    base.PlaceBid(buyoutBid);
                    Console.WriteLine("Buyout met by " + offeredBid.Bidder);
                    base.HasEnded = true;
                    isNewHighBid = true; 
                }
                else
                {
                    isNewHighBid = base.PlaceBid(offeredBid); 
                }
            }                    

            // Output the current high bid
            Console.WriteLine($"Current high bid: {CurrentHighBid.BidAmount} offered by {CurrentHighBid.Bidder}");

            // Return if this is the new highest bid
            return isNewHighBid;

        }
    }
}
