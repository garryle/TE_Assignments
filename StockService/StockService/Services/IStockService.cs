using System;
using System.Collections.Generic;

namespace Stocks
{
    interface IStockService
    {
        List<MarketData> GetMarketDataItems(List<String> symbols);
        MarketData GetMarketDataItem(String symbol);
        List<MarketData> GetAllMarketDataItems();
        Company GetCompanyData(String symbol);
    }
}
