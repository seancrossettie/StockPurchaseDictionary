using System;
using System.Collections.Generic;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("AAPL", "Apple");

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();

            purchases.Add(("GM", 20, 300.51));
            purchases.Add(("GM", 25, 305.21));
            purchases.Add(("GM", 24, 303.21));
            purchases.Add(("CAT", 15, 65.34));
            purchases.Add(("CAT", 16, 67.34));
            purchases.Add(("CAT", 17, 68.34));
            purchases.Add(("CAT", 90, 60.34));
            purchases.Add(("AAPL", 10, 165.34));
            purchases.Add(("AAPL", 10, 169.35));
            purchases.Add(("AAPL", 10, 165.38));
            purchases.Add(("AAPL", 16, 178.34));

            Dictionary<string, double> report = new Dictionary<string, double>();

            foreach(var purchase in purchases)
            {
                var totalValue = purchase.shares * purchase.price; 
                if (report.ContainsKey(purchase.ticker))
                {
                    report[purchase.ticker] += totalValue;
                } else
                {
                    report.Add(purchase.ticker, totalValue);
                }
            }

            foreach(var reportable in report)
            {
                foreach(var stock in stocks)
                {
                    if (stock.Key == reportable.Key)
                    {
                        Console.WriteLine($"{stock.Value} : {Math.Round(reportable.Value, 2)}");
                    }
                }
            }
        }
    }
}
