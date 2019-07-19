using ZESoft.Services.DateTimeService;

namespace IEX.Net
{
    /// <summary>
    /// Object for configuring access to the IEX Cloud.
    /// </summary>
    public class IEXClientConfig : IIEXClientConfig
    {
        /// <summary>
        /// Gets the public key.
        /// </summary>
        /// <value>
        /// The public key.
        /// </value>
        public string PublicKey { get; }
        /// <summary>
        /// Gets the secret key.
        /// </summary>
        /// <value>
        /// The secret key.
        /// </value>
        public string SecretKey { get; }

        /// <summary>
        /// Gets the IEX api version.
        /// </summary>
        /// <value>
        /// The IEX api version.
        /// </value>
        public IEXApiVersion Version { get; }
        /// <summary>
        /// Gets the date time provider.
        /// </summary>
        /// <value>
        /// The date time provider.
        /// </value>
        public IDateTimeProvider DateTimeProvider { get; }

        /// <summary>
        /// Gets the protocol.
        /// </summary>
        /// <value>
        /// The protocol.
        /// </value>
        public string Protocol { get; }
        /// <summary>
        /// Gets the domain.
        /// </summary>
        /// <value>
        /// The domain.
        /// </value>
        public string Domain { get; }
        /// <summary>
        /// Gets the version endpoint.
        /// </summary>
        /// <value>
        /// The version endpoint.
        /// </value>
        public string VersionEndpoint { get; }
        /// <summary>
        /// Gets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        public string BaseUrl { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IEXClientConfig"/> class.
        /// </summary>
        /// <param name="publicKey">Your IEX Cloud Api public key.</param>
        /// <param name="secretKey">Your IEX Cloud Api secret key.</param>
        /// <param name="apiVerison">The IEX Cloud API verison you want to target.</param>
        /// <param name="dateTimeProvider">The date time provider for iex date header. Defaults to UTC if null and likely do not want to change.</param>
        public IEXClientConfig(string publicKey, string secretKey, IEXApiVersion apiVerison = IEXApiVersion.Stable, IDateTimeProvider dateTimeProvider = null)
        {
            PublicKey = publicKey;
            SecretKey = secretKey;
            Version = apiVerison;
            Protocol = BaseUrls.HTTPS_PROTOCOL;

            DateTimeProvider = dateTimeProvider ?? new UtcDateTimeProvider();

            Domain = BaseUrls.DOMAIN;
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
            VersionEndpoint = BaseUrl.Replace(BaseUrls.BASE_URL, "");
        }

        //public IEXClientConfig(string publicKey, string secretKey, string customHost, string customBaseUrl)
        //{
        //    PublicKey = publicKey;
        //    SecretKey = secretKey;
        //    Domain = customHost;
        //    BaseUrl = customBaseUrl;
        //}
    }
}
