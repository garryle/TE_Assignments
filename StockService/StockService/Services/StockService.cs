using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Stocks
{
    public class StockService : IStockService
    {
        public List<MarketData> GetAllMarketDataItems()
        {
            List<MarketData> stocks = null;

            var req = WebRequest.Create("https://api.iextrading.com/1.0/tops");
            var stream = req.GetResponse().GetResponseStream();
            using (StreamReader sr = new StreamReader(stream))
            {
                var jsonStr = sr.ReadToEnd();
                stocks = JsonConvert.DeserializeObject<List<MarketData>>(jsonStr);
            }

            return stocks;
        }

        public MarketData GetMarketDataItem(String symbol)
        {
            var symbols = new List<String>();
            symbols.Add(symbol);
            var stocks = GetMarketDataItems(symbols);
            return stocks.ElementAt(0);
        }

        public List<MarketData> GetMarketDataItems(List<String> symbols)
        {
            List<MarketData> stocks = null;

            String uri = "https://api.iextrading.com/1.0/tops?symbols=";
            bool isFirstTime = true;
            foreach (var symbol in symbols)
            {
                if (!isFirstTime)
                {
                    uri += ",";
                }
                else
                {
                    isFirstTime = false;
                }
                uri += symbol;
            }
            var req = WebRequest.Create(uri);
            var stream = req.GetResponse().GetResponseStream();
            using (StreamReader sr = new StreamReader(stream))
            {
                var jsonStr = sr.ReadToEnd();
                stocks = JsonConvert.DeserializeObject<List<MarketData>>(jsonStr);                    
            }

            return stocks;
        }

        public Company GetCompanyData(String symbol)
        {
            Company stock = null;
            
            String uri = "https://api.iextrading.com/1.0/stock/" + symbol + "/company";
            var req = WebRequest.Create(uri);
            var stream = req.GetResponse().GetResponseStream();
            using (StreamReader sr = new StreamReader(stream))
            {
                var jsonStr = sr.ReadToEnd();
                stock = JsonConvert.DeserializeObject<Company>(jsonStr);
            }

            return stock;
        }
    }
}
