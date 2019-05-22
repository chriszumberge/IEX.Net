using Newtonsoft.Json;

namespace IEX.Net
{
    public class Quote : ObservableObject
    {
        string _symbol;
        [JsonProperty("symbol")]
        public string Symbol
        {
            get { return _symbol; }
            set { SetProperty(ref _symbol, value); }
        }

        string _companyName;
        [JsonProperty("companyName")]
        public string CompanyName
        {
            get { return _companyName; }
            set { SetProperty(ref _companyName, value); }
        }

        string _calculationPrice;
        [JsonProperty("calculationPrice")]
        public string CalculationPrice
        {
            get { return _calculationPrice; }
            set { SetProperty(ref _calculationPrice, value); }
        }

        double _open;
        [JsonProperty("open")]
        public double Open
        {
            get { return _open; }
            set { SetProperty(ref _open, value); }
        }

        long _openTime;
        [JsonProperty("openTime")]
        public long OpenTime
        {
            get { return _openTime; }
            set { SetProperty(ref _openTime, value); }
        }

        double _close;
        [JsonProperty("close")]
        public double Close
        {
            get { return _close; }
            set { SetProperty(ref _close, value); }
        }

        long _closeTime;
        [JsonProperty("closeTime")]
        public long CloseTime
        {
            get { return _closeTime; }
            set { SetProperty(ref _closeTime, value); }
        }

        double _high;
        [JsonProperty("high")]
        public double High
        {
            get { return _high; }
            set { SetProperty(ref _high, value); }
        }

        double _low;
        [JsonProperty("low")]
        public double Low
        {
            get { return _low; }
            set { SetProperty(ref _low, value); }
        }

        double _latestPrice;
        [JsonProperty("latestPrice")]
        public double LatestPrice
        {
            get { return _latestPrice; }
            set { SetProperty(ref _latestPrice, value); }
        }

        string _latestSource;
        [JsonProperty("latestSource")]
        public string LatestSource
        {
            get { return _latestSource; }
            set { SetProperty(ref _latestSource, value); }
        }

        string _latestTime;
        [JsonProperty("latestTime")]
        public string LatestTime
        {
            get { return _latestTime; }
            set { SetProperty(ref _latestTime, value); }
        }

        long _latestUpdate;
        [JsonProperty("latestUpdate")]
        public long LatestUpdate
        {
            get { return _latestUpdate; }
            set { SetProperty(ref _latestUpdate, value); }
        }

        long _latestVolume;
        [JsonProperty("latestVolume")]
        public long LatestVolume
        {
            get { return _latestVolume; }
            set { SetProperty(ref _latestVolume, value); }
        }

        double _iexRealtimePrice;
        [JsonProperty("iexRealtimePrice")]
        public double IexRealtimePrice
        {
            get { return _iexRealtimePrice; }
            set { SetProperty(ref _iexRealtimePrice, value); }
        }

        long _iexRealtimeSize;
        [JsonProperty("iexRealtimeSize")]
        public long IexRealtimeSize
        {
            get { return _iexRealtimeSize; }
            set { SetProperty(ref _iexRealtimeSize, value); }
        }

        long _iexLastUpdated;
        [JsonProperty("iexLastUpdated")]
        public long IexLastUpdated
        {
            get { return _iexLastUpdated; }
            set { SetProperty(ref _iexLastUpdated, value); }
        }

        double _delayedPrice;
        [JsonProperty("delayedPrice")]
        public double DelayedPrice
        {
            get { return _delayedPrice; }
            set { SetProperty(ref _delayedPrice, value); }
        }

        long _delayedPriceTime;
        [JsonProperty("delayedPriceTime")]
        public long DelayedPriceTime
        {
            get { return _delayedPriceTime; }
            set { SetProperty(ref _delayedPriceTime, value); }
        }

        double _extendedPrice;
        [JsonProperty("extendedPrice")]
        public double ExtendedPrice
        {
            get { return _extendedPrice; }
            set { SetProperty(ref _extendedPrice, value); }
        }

        double _extendedChange;
        [JsonProperty("extendedChange")]
        public double ExtendedChange
        {
            get { return _extendedChange; }
            set { SetProperty(ref _extendedChange, value); }
        }

        double _extendedChangePercent;
        [JsonProperty("extendedChangePercent")]
        public double ExtendedChangePercent
        {
            get { return _extendedChangePercent; }
            set { SetProperty(ref _extendedChangePercent, value); }
        }

        long _extendedPriceTime;
        [JsonProperty("extendedPriceTime")]
        public long ExtendedPriceTime
        {
            get { return _extendedPriceTime; }
            set { SetProperty(ref _extendedPriceTime, value); }
        }

        double _previousClose;
        [JsonProperty("previousClose")]
        public double PreviousClose
        {
            get { return _previousClose; }
            set { SetProperty(ref _previousClose, value); }
        }

        double _change;
        [JsonProperty("change")]
        public double Change
        {
            get { return _change; }
            set { SetProperty(ref _change, value); }
        }

        double _changePercent;
        [JsonProperty("changePercent")]
        public double ChangePercent
        {
            get { return _changePercent; }
            set { SetProperty(ref _changePercent, value); }
        }

        double _iexMarketPercent;
        [JsonProperty("iexMarketPercent")]
        public double IexMarketPercent
        {
            get { return _iexMarketPercent; }
            set { SetProperty(ref _iexMarketPercent, value); }
        }

        long _iexVolume;
        [JsonProperty("iexVolume")]
        public long IexVolume
        {
            get { return _iexVolume; }
            set { SetProperty(ref _iexVolume, value); }
        }

        long _avgTotalVolume;
        [JsonProperty("avgTotalVolume")]
        public long AvgTotalVolume
        {
            get { return _avgTotalVolume; }
            set { SetProperty(ref _avgTotalVolume, value); }
        }

        double _iexBidPrice;
        [JsonProperty("iexBidPrice")]
        public double IexBidPrice
        {
            get { return _iexBidPrice; }
            set { SetProperty(ref _iexBidPrice, value); }
        }

        long _iexBidSize;
        [JsonProperty("iexBidSize")]
        public long IexBidSize
        {
            get { return _iexBidSize; }
            set { SetProperty(ref _iexBidSize, value); }
        }

        double _iexAskPrice;
        [JsonProperty("iexAskPrice")]
        public double IexAskPrice
        {
            get { return _iexAskPrice; }
            set { SetProperty(ref _iexAskPrice, value); }
        }

        long _iexAskSize;
        [JsonProperty("iexAskSize")]
        public long IexAskSize
        {
            get { return _iexAskSize; }
            set { SetProperty(ref _iexAskSize, value); }
        }

        long _marketCap;
        [JsonProperty("marketCap")]
        public long MarketCap
        {
            get { return _marketCap; }
            set { SetProperty(ref _marketCap, value); }
        }

        double _peRatio;
        [JsonProperty("peRatio")]
        public double PeRatio
        {
            get { return _peRatio; }
            set { SetProperty(ref _peRatio, value); }
        }

        double _week52High;
        [JsonProperty("week52High")]
        public double Week52High
        {
            get { return _week52High; }
            set { SetProperty(ref _week52High, value); }
        }

        double _week52Low;
        [JsonProperty("week52Low")]
        public double Week52Low
        {
            get { return _week52Low; }
            set { SetProperty(ref _week52Low, value); }
        }

        double _ytdChange;
        [JsonProperty("ytdChange")]
        public double YtdChange
        {
            get { return _ytdChange; }
            set { SetProperty(ref _ytdChange, value); }
        }

        public static Quote FromJson(string json) => JsonConvert.DeserializeObject<Quote>(json, Converter.Settings);
    }
}
