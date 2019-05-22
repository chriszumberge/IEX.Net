using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IEX.Net
{
    public class IEXClient
    {
        // TODO SANDBOX IEX CLIENT (https://sandbox.iexapis.com)
        // TODO support streaming (events)

        IEXClientConfig _config;

        string _host => _config?.Host ?? "";
        string _accessKey => _config?.PublicKey ?? "";
        string _secretKey => _config?.SecretKey ?? "";
        string _baseUri => _config?.BaseUrl ?? "";

        string _canonicalQueryString => $"token={_accessKey}";
        

        public IEXClient(IEXClientConfig configuration)
        {
            _config = configuration;
        }

        public Task<Company> GetCompanyAsync(string symbol)
        {
            return MakeSignedRequestAsync<Company>("GET", DateTime.UtcNow, $"stock/{symbol}/company");
        }

        public Task<List<Dividend>> GetDividendAsync(string symbol, string range = "1m")
        {
            return MakeSignedRequestAsync<List<Dividend>>("GET", DateTime.UtcNow, $"/stock/{symbol}/dividends/{range}");
        }

        public Task<Quote> GetQuoteAsync(string symbol)
        {
            // Can do this call unsigned if need be
            if (String.IsNullOrEmpty(_accessKey) || String.IsNullOrEmpty(_secretKey))
            {
                return MakeRequestAsync<Quote>("GET", $"stock/{symbol}/quote");
            }
            else
            {
                return MakeSignedRequestAsync<Quote>("get", DateTime.Now, $"stock/{symbol}/quote");
            }
        }

        public Task<double> GetPriceAsync(string symbol)
        {
            return MakeRequestAsync<double>("GET", $"/stock/{symbol}/price");
        }

        async Task<T> MakeRequestAsync<T>(string method, string requestUri, string queryString = "")
        {
            using (var cli = new HttpClient())
            {
                string canonicalUri = $"{_baseUri}{requestUri}".Replace(_host, "").Replace("https://", "");
                string canonicalQueryString = $"token={_accessKey}{queryString}";
                string endpoint = $"https://{_host}{canonicalUri}";

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

        async Task<T> MakeSignedRequestAsync<T>(string method, DateTime requestDT, string requestUri, string queryString = "")
        {
            using (var cli = new HttpClient())
            {

                string iexDate = requestDT.ToString("yyyyMMddTHHmmssZ");
                string datestamp = requestDT.ToString("yyyyMMdd");

                string canonicalHeaders = $"host:{_host}\nx-iex-date:{iexDate}\n";
                string signedHeaders = "host;x-iex-date";

                // TODO
                string canonicalUri = $"{_baseUri}{requestUri}".Replace(_host, "").Replace("https://", "");

                string canonicalQueryString = $"token={_accessKey}{queryString}";
                string endpoint = $"https://{_host}{canonicalUri}";

                // TODO move to calling code, if payload isn't empty??
                string payloadHash = GetHash("");
                //canonical_request = method + '\n' + canonical_uri + '\n' + canonical_querystring + '\n' + canonical_headers + '\n' + signed_headers + '\n' + payload_hash
                string canonicalRequest = $"{method}\n{canonicalUri}\n{canonicalQueryString}\n{canonicalHeaders}\n{signedHeaders}\n{payloadHash}";
                string algorithm = "IEX-HMAC-SHA256";
                string credentialScope = $"{datestamp}/iex_request";
                //algorithm + '\n' + iexdate + '\n' + credential_scope + '\n' + hashlib.sha256(canonical_request.encode('utf-8')).hexdigest()
                string stringToSign = $"{algorithm}\n{iexDate}\n{credentialScope}\n{GetHash(canonicalRequest)}";
                string signingKey = GetSignatureKey(_secretKey, datestamp);
                string signature = Sign(signingKey, stringToSign);
                //algorithm + ' ' + 'Credential=' + access_key + '/' + credential_scope + ', ' + 'SignedHeaders=' + signed_headers + ', ' + 'Signature=' + signature
                string authorizationHeader = $"{algorithm} Credential={_accessKey}/{credentialScope}, SignedHeaders={signedHeaders}, Signature={signature}";

                var auth = authorizationHeader;

                //cli.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(auth);
                cli.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", auth);
                //cli.DefaultRequestHeaders.Date = requestDT;
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

        //static string GenerateHMACPayload(string method, string token, DateTime dt)
        //{
        //    return string.Format("{0}\n{1}\n{2}\n", method, refToken, dt.ToString(DateFormat));
        //}

        //static string CreateHMAC(string key, string message)
        //{
        //    key = key ?? "";
        //    var encoding = new System.Text.UTF8Encoding();
        //    byte[] keyByte = encoding.GetBytes(key);
        //    byte[] messageBytes = encoding.GetBytes(message);
        //    using (var hmacsha256 = new HMACSHA256(keyByte))
        //    {
        //        byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
        //        return Convert.ToBase64String(hashmessage);
        //    }
        //}
    }
}
