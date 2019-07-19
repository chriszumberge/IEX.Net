using ZESoft.Services.DateTimeService;

namespace IEX.Net
{
    public interface IIEXClientConfig
    {
        string BaseUrl { get; }
        IDateTimeProvider DateTimeProvider { get; }
        string Domain { get; }
        string Protocol { get; }
        string PublicKey { get; }
        string SecretKey { get; }
        IEXApiVersion Version { get; }
        string VersionEndpoint { get; }
    }
}