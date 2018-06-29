using IEX.Net.Models;
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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Concat(URL_BASE, requestUrl));
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            string responseJson = String.Empty;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseJson = await reader.ReadToEndAsync();
            }

            return Company.FromJson(responseJson);
        }
    }
}
