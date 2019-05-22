using System;
using System.Collections.Generic;
using System.Text;

namespace IEX.Net
{
    public class IEXClientConfig
    {
        public string PublicKey { get; }
        public string SecretKey { get; }

        public string Host { get; }
        public string BaseUrl { get; }

        public IEXClientConfig(string publicKey, string secretKey, IEXApiVersion apiVerison = IEXApiVersion.Stable)
        {
            PublicKey = publicKey;
            SecretKey = secretKey;

            Host = BaseUrls.HOST;
            switch(apiVerison)
            {
                case IEXApiVersion.Stable:
                    BaseUrl = BaseUrls.STABLE;
                    break;
                case IEXApiVersion.V1:
                    BaseUrl = BaseUrls.VERSION_1;
                    break;
                case IEXApiVersion.Beta:
                    BaseUrl = BaseUrls.BETA;
                    break;
                case IEXApiVersion.Latest:
                    BaseUrl = BaseUrls.LATEST;
                    break;
            }
        }

        public IEXClientConfig(string publicKey, string secretKey, string customHost, string customBaseUrl)
        {
            PublicKey = publicKey;
            SecretKey = secretKey;
            Host = customHost;
            BaseUrl = customBaseUrl;
        }
    }
}
