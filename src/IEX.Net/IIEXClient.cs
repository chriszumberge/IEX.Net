using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEX.Net
{
    public interface IIEXClient
    {
        Task<Company> GetCompanyAsync(string symbol);
        Task<List<Dividend>> GetDividendAsync(string symbol, DataRange range = null);
        Task<List<MarketVolume>> GetMarketVolumeAsync();
        Task<List<News>> GetNewsAsync(string symbol, int maxResults = 10);
        Task<List<string>> GetPeersAsync(string symbol);
        Task<double> GetPriceAsync(string symbol);
        Task<Quote> GetQuoteAsync(string symbol);
        Task<PriceTarget> GetPriceTargetAsync(string symbol);
        Task<List<Recommendation>> GetRecommendationsAsync(string symbol);
        Task<List<SectorPerformance>> GetSectorPerformancesAsync();
    }
}