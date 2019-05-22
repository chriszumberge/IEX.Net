namespace IEX.Net
{
    internal static class BaseUrls
    {
        private const string HTTPS_PROTOCOL = "https://";
        internal const string HOST = "cloud.iexapis.com";

        private const string BASE = HTTPS_PROTOCOL + HOST + "/";

        internal const string VERSION_1 = BASE + "v1/";
        internal const string LATEST = BASE + "latest/";
        internal const string STABLE = BASE + "stable/";
        internal const string BETA = BASE + "beta/";
    }

    public enum DataRanges
    {
        FiveYear,
        TwoYear,
        OneYear,
        YearToDate,
        SixMonth,
        ThreeMonth,
        OneMonth,
        Next
    }
}
