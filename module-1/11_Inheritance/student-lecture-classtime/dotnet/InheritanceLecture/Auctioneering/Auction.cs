using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceLecture.Auctioneering
{
    /// <summary>
    /// This class represents a general auction.
    /// </summary>
    public class Auction
    {
        /// <summary>
        /// This is an encapsulated field that holds all placed bids.
        /// </summary>
        private List<Bid> allBids = new List<Bid>();

        /// <summary>
        /// Represents the current high bid.
        /// </summary>
        public Bid CurrentHighBid { get; private set; } = new Bid("", 0);

        /// <summary>
        /// All placed bids returned as an array.
        /// </summary>
        public Bid[] AllBids
        {
            get { return allBids.ToArray(); }
        }

        public Auction()
        {
            Console.WriteLine("in Auction constructor");
        }

        /// <summary>
        /// Indicates if the auction has ended yet.
        /// </summary>
        public bool HasEnded { get; protected set; }

        /// <summary>
        /// Places a Bid on the Auction
        /// </summary>
        /// <param name="offeredBid">The bid to place.</param>
        /// <returns>True if the new bid is the current winning bid</returns>
        public virtual bool PlaceBid(Bid offeredBid)
        {
            bool isNewHighBid = false;

            // Print out the bid details.
            Console.WriteLine($"Bid of {offeredBid.BidAmount} offered by {offeredBid.Bidder} in Auction PlaceBid");

            // Record it as a bid by adding it to allBids
            allBids.Add(offeredBid);

            // Check to see IF the offered bid is higher than the current bid amount
            // if yes, set offered bid as the current high bid
            if (offeredBid.BidAmount > CurrentHighBid.BidAmount)
            {
                CurrentHighBid = offeredBid;
                isNewHighBid = true;
            }

            // Output the current high bid
            Console.WriteLine($"Current high bid: {CurrentHighBid.BidAmount} offered by {CurrentHighBid.Bidder}");

            // Return if this is the new highest bid
            return isNewHighBid;            
        }                
    }
}
