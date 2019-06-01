namespace IEX.Net
{
    internal static class BaseUrls
    {
        internal const string HTTPS_PROTOCOL = "https://";
        internal const string DOMAIN = "cloud.iexapis.com";

        internal const string BASE_URL = HTTPS_PROTOCOL + DOMAIN + "/";

        internal const string VERSION_1 = BASE_URL + "v1/";
        internal const string LATEST = BASE_URL + "latest/";
        internal const string STABLE = BASE_URL + "stable/";
        internal const string BETA = BASE_URL + "beta/";
    }

    internal static class HttpMethods
    {
        internal const string GET = "GET";
        internal const string POST = "POST";
    }
}
