using Stocks;
using System.Collections.Generic;

namespace StockCLI
{
    class Program
    {
        static void Main(string[] args)
        {

            StockService stockSvc = new StockService();
            List<MarketData> marketData = stockSvc.GetAllMarketDataItems();
            Company companyDetails = stockSvc.GetCompanyData("coe");
            MarketData item = stockSvc.GetMarketDataItem("coe");

        }
    }
}
