using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IEX.Net
{
    /// <summary>
    /// Client object for making calls to the IEX Cloud.
    /// </summary>
    public class IEXClient
    {
        // TODO SANDBOX IEX CLIENT (https://sandbox.iexapis.com)
        // TODO support streaming (events)

        IEXClientConfig _config;

        string _host => _config?.Domain ?? "";
        string _accessKey => _config?.PublicKey ?? "";
        string _secretKey => _config?.SecretKey ?? "";
        string _baseUri => _config?.BaseUrl ?? "";      

        string _canonicalQueryString => $"token={_accessKey}";


        /// <summary>
        /// Initializes a new instance of the <see cref="IEXClient"/> class using the given configuration object.
        /// </summary>
        /// <param name="configuration">The configuration definiton object.</param>
        public IEXClient(IEXClientConfig configuration)
        {
            _config = configuration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IEXClient"/> class using the given keys and default configuration values.
        /// </summary>
        /// <param name="publicKey">Your IEX Cloud Api public key.</param>
        /// <param name="secretKey">Your IEX Cloud Api secret key.</param>
        public IEXClient(string publicKey, string secretKey) : this(new IEXClientConfig(publicKey, secretKey)) { }


        /// <summary>
        /// Gets information about a company with the given symbol asynchronously.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>Company object, or null if none is found with the given symbol.</returns>
        public Task<Company> GetCompanyAsync(string symbol)
        {
            return MakeSignedRequestAsync<Company>(HttpMethods.GET, _config.DateTimeProvider.GetDateTime(), $"stock/{symbol}/company");
        }

        /// <summary>
        /// Gets a list of dividend action for the given symbol over the given data range.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <param name="range">The range.</param>
        /// <returns>List of Dividend objects for each dividend action in the range.</returns>
        public Task<List<Dividend>> GetDividendAsync(string symbol, DataRange range = null)
        {
            range = range ?? DataRange.OneMonth;

            return MakeSignedRequestAsync<List<Dividend>>(HttpMethods.GET, _config.DateTimeProvider.GetDateTime(), $"stock/{symbol}/dividends/{range}");
        }

        /// <summary>
        /// Gets the real time traded volume on U.S. markets.
        /// </summary>
        /// <returns>List of MarketVolume objects for each of the U.S. markets.</returns>
        public Task<List<MarketVolume>> GetMarketVolumeAsync()
        {
            return MakeSignedRequestAsync<List<MarketVolume>>(HttpMethods.GET, _config.DateTimeProvider.GetDateTime(), $"market");
        }

        /// <summary>
        /// Gets news items for the given symbol asynchronously.
        /// </summary>
        /// <param name="symbol">The symbol to get news for.</param>
        /// <param name="maxResults">The maximum results. Number between 1 and 50. Default is 10.</param>
        /// <returns>
        /// List of News objects for the given symbol.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">maxResults - Argument must be an integer between 1 and 50.</exception>
        public Task<List<News>> GetNewsAsync(string symbol, int maxResults = 10)
        {
            if (maxResults < 1 || maxResults > 50)
            {
                throw new ArgumentOutOfRangeException(nameof(maxResults), maxResults, $"Argument must be an integer between 1 and 50.");
            }

            return MakeSignedRequestAsync<List<News>>(HttpMethods.GET, _config.DateTimeProvider.GetDateTime(), $"stock/{symbol}/news/last/{maxResults}");
        }

        /// <summary>
        /// Gets a list of peer companies to the given company asynchronously.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>A list of symbols of peer companies.</returns>
        public Task<List<string>> GetPeersAsync(string symbol)
        {
            return MakeSignedRequestAsync<List<string>>(HttpMethods.GET, _config.DateTimeProvider.GetDateTime(), $"stock/{symbol}/peers");
        }

        /// <summary>
        /// Gets the price of a symbol asynchronously.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>The price.</returns>
        public Task<double> GetPriceAsync(string symbol)
        {
            return MakeRequestAsync<double>(HttpMethods.GET, $"stock/{symbol}/price");
        }

        /// <summary>
        /// Gets the a quote for a symbol asynchronously.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>Quote for the given symbol.</returns>
        public Task<Quote> GetQuoteAsync(string symbol)
        {
            // Can do this call unsigned if need be
            if (String.IsNullOrEmpty(_accessKey) || String.IsNullOrEmpty(_secretKey))
            {
                return MakeRequestAsync<Quote>(HttpMethods.GET, $"stock/{symbol}/quote");
            }
            else
            {
                return MakeSignedRequestAsync<Quote>(HttpMethods.GET, _config.DateTimeProvider.GetDateTime(), $"stock/{symbol}/quote");
            }
        }

        /// <summary>
        /// Returns an array of recommendations for the given symbol, over the last four months, asynchronously.
        /// </summary>
        /// <param name="symbol">The symbol to pull recommendations for.</param>
        /// <returns>List of Recommendations for the given symbol.</returns>
        public Task<List<Recommendation>> GetRecommendationsAsync(string symbol)
        {
            return MakeSignedRequestAsync<List<Recommendation>>(HttpMethods.GET, _config.DateTimeProvider.GetDateTime(), $"stock/{symbol}/recommendation-trends");
        }

        /// <summary>
        /// Returns an array of each sector and performance for the current trading day asynchronously. 
        /// Performance is based on each sector ETF.
        /// </summary>
        /// <returns>List of SectorPerformance objects for each sector.</returns>
        public Task<List<SectorPerformance>> GetSectorPerformancesAsync()
        {
            return MakeSignedRequestAsync<List<SectorPerformance>>(HttpMethods.GET, _config.DateTimeProvider.GetDateTime(), $"/stock/market/sector-performance");
        }


        async Task<T> MakeRequestAsync<T>(string method, string requestUri, string queryString = "")
        {
            using (var cli = new HttpClient())
            {
                string canonicalUri = $"/{_config.VersionEndpoint}{requestUri}";
                string canonicalQueryString = $"token={_accessKey}{queryString}";
                string endpoint = $"{_config.Protocol}{_host}{canonicalUri}";

                // TODO methods
                HttpResponseMessage resp = await cli.GetAsync($"{endpoint}?{canonicalQueryString}");

                if (resp.IsSuccessStatusCode)
                {
                    string serializedContent = await resp.Content.ReadAsStringAsync();
                    T content = await new TaskFactory().StartNew(() => JsonConvert.DeserializeObject<T>(serializedContent, Converter.Settings));
                    return content;
                }
                else
                {
                    Console.WriteLine("Got error: {0} {1}", resp.StatusCode, resp.ReasonPhrase);
                    return default(T);
                }
            }
        }

        static string s_iexDateFormat = "yyyyMMddTHHmmssZ";
        static string s_datestampFormat = "yyyyMMdd";

        async Task<T> MakeSignedRequestAsync<T>(string method, DateTime requestDT, string requestUri, string queryString = "", string payload = "")
        {
            using (var cli = new HttpClient())
            {
                string iexDate = requestDT.ToString(s_iexDateFormat);
                string datestamp = requestDT.ToString(s_datestampFormat);

                string canonicalHeaders = $"host:{_host}\nx-iex-date:{iexDate}\n";
                string signedHeaders = "host;x-iex-date";

                string canonicalUri = $"/{_config.VersionEndpoint}{requestUri}";

                string canonicalQueryString = $"token={_accessKey}{queryString}";
                string endpoint = $"{_config.Protocol}{_host}{canonicalUri}";

                string payloadHash = GetHash(payload);
                
                string canonicalRequest = $"{method}\n{canonicalUri}\n{canonicalQueryString}\n{canonicalHeaders}\n{signedHeaders}\n{payloadHash}";
                string algorithm = "IEX-HMAC-SHA256";
                string credentialScope = $"{datestamp}/iex_request";
                
                string stringToSign = $"{algorithm}\n{iexDate}\n{credentialScope}\n{GetHash(canonicalRequest)}";
                string signingKey = GetSignatureKey(_secretKey, datestamp);
                string signature = Sign(signingKey, stringToSign);
                
                string authorizationHeader = $"{algorithm} Credential={_accessKey}/{credentialScope}, SignedHeaders={signedHeaders}, Signature={signature}";

                var auth = authorizationHeader;

                cli.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", auth);
                cli.DefaultRequestHeaders.Add("x-iex-date", iexDate);

                // TODO methods
                HttpResponseMessage resp = await cli.GetAsync($"{endpoint}?{canonicalQueryString}");

                if (resp.IsSuccessStatusCode)
                {
                    string serializedContent = await resp.Content.ReadAsStringAsync();
                    T content = await new TaskFactory().StartNew(() => JsonConvert.DeserializeObject<T>(serializedContent, Converter.Settings));
                    return content;
                }
                else
                {
                    Console.WriteLine("Got error: {0} {1}", resp.StatusCode, resp.ReasonPhrase);
                    return default(T);
                }
            }
        }

        static Encoding s_Encoding = new System.Text.UTF8Encoding();
        static string Sign(string key, string msg)
        {
            key = key ?? "";
            byte[] keyBytes = s_Encoding.GetBytes(key);
            byte[] msgBytes = s_Encoding.GetBytes(msg);
            using (var hmacsha256 = new HMACSHA256(keyBytes))
            {
                byte[] hashMessage = hmacsha256.ComputeHash(msgBytes);
                //return Convert.ToBase64String(hashMessage);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashMessage)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        static string GetHash(string message)
        {
            byte[] msgBytes = s_Encoding.GetBytes(message);
            using (var sha256 = SHA256.Create())
            {
                byte[] hashMsg = sha256.ComputeHash(msgBytes);
                //return Convert.ToBase64String(hashMsg);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashMsg)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        static string GetSignatureKey(string key, string dateStamp)
        {
            string kDate = Sign(key, dateStamp);
            return Sign(kDate, "iex_request");
        }
    }
}
