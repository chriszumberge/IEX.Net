using IEX.Net.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IEX.Net
{
    public class IEXClient
    {
        const string URL_BASE = "https://api.iextrading.com/1.0/";

        /// <summary>
        /// Gets information about a company given the company's stock symbol.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>Company information.</returns>
        public async Task<Company> GetCompanyAsync(string symbol)
        {
            string requestUrl = $"/stock/{symbol}/company";
            string responseJson = await CreateAndSendRequest(requestUrl);

            return Company.FromJson(responseJson);
        }

        public async Task<Dividend[]> GetDividendsAsync(string symbol, Range range = null)
        {
            string requestUrl = $"/stock/{symbol}/dividends/{range ?? Range.Default}";
            string responseJson = await CreateAndSendRequest(requestUrl);

            return Dividend.FromJson(responseJson);
        }

        public async Task<double> GetPriceAsync(string symbol)
        {
            string requestUrl = $"/stock/{symbol}/price";
            string responseJson = await CreateAndSendRequest(requestUrl);

            return JsonConvert.DeserializeObject<double>(responseJson);
        }

        /// <summary>
        /// Returns an array of symbols that IEX supports for trading.
        /// List is updated daily as of 7:45 am ET.
        /// </summary>
        /// <returns></returns>
        public async Task<Symbol[]> GetSymbolsAsync()
        {
            string requestUrl = $"/ref-data/symbols";
            string responseJson = await CreateAndSendRequest(requestUrl);

            return Symbol.FromJson(responseJson);
        }

        static async Task<string> CreateAndSendRequest(string requestUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Concat(URL_BASE, requestUrl));
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            string responseJson = String.Empty;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseJson = await reader.ReadToEndAsync();
            }

            return responseJson;
        }
    }

    public class Range
    {
        public static Range FiveYears => new Range("5y");
        public static Range TwoYears => new Range("2y");
        public static Range OneYear => new Range("1y");
        public static Range YearToDate => new Range("ytd");
        public static Range SixMonths => new Range("6m");
        public static Range ThreeMonths => new Range("3m");
        public static Range OneMonth => new Range("1m");

        public static Range Default => OneMonth;

        string _range;
        private Range(string range)
        {
            _range = range;
        }
        public override string ToString()
        {
            return _range;
        }
    }
}
