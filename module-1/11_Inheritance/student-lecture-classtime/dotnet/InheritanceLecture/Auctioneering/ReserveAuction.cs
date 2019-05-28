using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.Auctioneering
{
    /// <summary>
    /// A reserve aution has a minimum reserve price that must be met in order for a bid to be considered
    /// </summary>
    class ReserveAuction : Auction
    {
        private int reservePrice;

        public ReserveAuction(int reservePrice)
        {
            this.reservePrice = reservePrice; 
        }

        public override bool PlaceBid(Bid offeredBid)
        {
            bool isNewHighBid = false;

            //only consider this bid if it meets the reserve price
            if (offeredBid.BidAmount >= reservePrice)
            {
                isNewHighBid = base.PlaceBid(offeredBid);
                Console.WriteLine("Reserve has been met");
            }
            else
            {
                Console.WriteLine("bid amount of " + offeredBid.BidAmount + " does not meet the reserve amount of "+ reservePrice +"!"); 
            }
            return isNewHighBid; 
        }
    }
}
