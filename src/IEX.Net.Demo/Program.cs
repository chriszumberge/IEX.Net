using System;
using System.Collections.Generic;

namespace IEX.Net.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IEXClientConfig config = new IEXClientConfig("pk_363a5bf9a47d48eb9685604f640f1f4a", new Func<string>(() => "sk_45a6d4763f2842d2a4a2a4ae93ec294e").Invoke());

            IEXClient client = new IEXClient(config);

            //Quote quote = client.GetQuoteAsync("aapl").Result;
            //Company company = client.GetCompanyAsync("aapl").Result;
            //List<Dividend> dividends = client.GetDividendAsync("aapl").Result;
            var price = client.GetPriceAsync("aapl").Result;

            Console.ReadLine();
        }
    }
}
