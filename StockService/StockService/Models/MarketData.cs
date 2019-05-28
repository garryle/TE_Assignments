using System;

namespace Stocks
{
    [Serializable]
    public class MarketData
    {
        public string Symbol { get; set; }
        public double MarketPercent { get; set; }
        public int BidSize { get; set; }
        public double BidPrice { get; set; }
        public int AskSize { get; set; }
        public double AskPrice { get; set; }
        public int Volume { get; set; }
        public double LastSalePrice { get; set; }
        public int LastSaleSize { get; set; }
        public long LastSaleTime { get; set; }
        public long LastUpdated { get; set; }
        public string Sector { get; set; }
        public string SecurityType { get; set; }

        public String GetLastSaleTime()
        {
            var time = new DateTime(LastSaleTime);
            return time.ToShortTimeString();
        }
        public String GetLastUpdatedTime()
        {
            var time = new DateTime(LastUpdated);
            return time.ToShortTimeString();
        }

        public MarketData Clone()
        {
            MarketData data = new MarketData();
            data.AskPrice = AskPrice;
            data.AskSize = AskSize;
            data.BidPrice = BidPrice;
            data.LastSalePrice = LastSalePrice;
            data.LastSaleSize = LastSaleSize;
            data.LastSaleTime = LastSaleTime;
            data.LastUpdated = LastUpdated;
            data.MarketPercent = MarketPercent;
            data.Sector = Sector;
            data.SecurityType = SecurityType;
            data.Symbol = Symbol;
            data.Volume = Volume;

            return data;
        }
    }
}