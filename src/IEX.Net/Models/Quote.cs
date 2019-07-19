using Newtonsoft.Json;
using System;
using ZESoft.Mvvm.Models;

namespace IEX.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ZESoft.Mvvm.Models.ObservableObject" />
    public class Quote : ObservableObject
    {
        string _symbol;
        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>
        /// Refers to the stock ticker.
        /// </value>
        [JsonProperty("symbol")]
        public string Symbol
        {
            get { return _symbol; }
            set { SetProperty(ref _symbol, value); }
        }

        string _companyName;
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// Refers to the company name.
        /// </value>
        [JsonProperty("companyName")]
        public string CompanyName
        {
            get { return _companyName; }
            set { SetProperty(ref _companyName, value); }
        }

        string _calculationPrice;
        /// <summary>
        /// Gets or sets the calculation price.
        /// </summary>
        /// <value>
        /// Refers to the source of the latest price. ("tops", "sip", "previousclose" or "close")
        /// </value>
        [JsonProperty("calculationPrice")]
        public string CalculationPrice
        {
            get { return _calculationPrice; }
            set { SetProperty(ref _calculationPrice, value); }
        }

        double? _open;
        /// <summary>
        /// Gets or sets the open.
        /// </summary>
        /// <value>
        /// Refers to the official open price from the SIP. 15 minute delayed (can be null after 00:00 ET, before 9:45 and weekends)
        /// </value>
        [JsonProperty("open")]
        public double? Open
        {
            get { return _open; }
            set { SetProperty(ref _open, value); }
        }

        long? _openTime;
        /// <summary>
        /// Gets or sets the open time.
        /// </summary>
        /// <value>
        /// Refers to the official listing exchange time for the open from the SIP. 15 minute delayed. Represented as millisecond epoch time.
        /// </value>
        [JsonProperty("openTime")]
        public long? OpenTime
        {
            get { return _openTime; }
            set { SetProperty(ref _openTime, value); }
        }
        /// <summary>
        /// Gets the open time as a <c>DateTimeOffset</c>.
        /// </summary>
        /// <value>
        /// The open time offset.
        /// </value>
        public DateTimeOffset? OpenTimeOffset => OpenTime.HasValue ?
            (DateTimeOffset?)DateTimeOffset.FromUnixTimeMilliseconds(OpenTime.Value) : null;
        /// <summary>
        /// Gets the open time as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The open time date time.
        /// </value>
        public DateTime? OpenTimeDateTime => OpenTimeOffset?.DateTime;

        double? _close;
        /// <summary>
        /// Gets or sets the close.
        /// </summary>
        /// <value>
        /// Refers to the official close price from the SIP. 15 minute delayed.
        /// </value>
        [JsonProperty("close")]
        public double? Close
        {
            get { return _close; }
            set { SetProperty(ref _close, value); }
        }

        long? _closeTime;
        /// <summary>
        /// Gets or sets the close time.
        /// </summary>
        /// <value>
        /// Refers to the official listing exchange time for the close from the SIP. 15 minute delayed. Represented as millisecond epoch time.
        /// </value>
        [JsonProperty("closeTime")]
        public long? CloseTime
        {
            get { return _closeTime; }
            set { SetProperty(ref _closeTime, value); }
        }
        /// <summary>
        /// Gets the close time as a <c>DateTimeOffset</c>.
        /// </summary>
        /// <value>
        /// The close time offset.
        /// </value>
        public DateTimeOffset? CloseTimeOffset => CloseTime.HasValue ?
            (DateTimeOffset?)DateTimeOffset.FromUnixTimeMilliseconds(CloseTime.Value) : null;
        /// <summary>
        /// Gets the close time as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The close time date time.
        /// </value>
        public DateTime? CloseTimeDateTime => CloseTimeOffset?.DateTime;

        double? _high;
        /// <summary>
        /// Gets or sets the high.
        /// </summary>
        /// <value>
        /// Refers to the market-wide highest price from the SIP. 15 minute delayed during normal market hours 9:30 - 16:00 (null before 9:45 and weekends).
        /// </value>
        [JsonProperty("high")]
        public double? High
        {
            get { return _high; }
            set { SetProperty(ref _high, value); }
        }

        double? _low;
        /// <summary>
        /// Gets or sets the low.
        /// </summary>
        /// <value>
        /// Refers to the market-wide lowest price from the SIP. 15 minute delayed during normal market hours 9:30 - 16:00 (null before 9:45 and weekends).
        /// </value>
        [JsonProperty("low")]
        public double? Low
        {
            get { return _low; }
            set { SetProperty(ref _low, value); }
        }

        double? _latestPrice;
        /// <summary>
        /// Gets or sets the latest price.
        /// </summary>
        /// <value>
        /// Use this to get the latest price.
        /// 
        /// Refers to the latest relevant price of the security which is derived from multiple sources. 
        /// We first look for an IEX real time price. If an IEX real time price is older than 15 minutes, 15 minute delayed market price is used. 
        /// If a 15 minute delayed price is not available, we will use the current day close price. 
        /// If a current day close price is not available, we will use the last available closing price (listed below as previousClose)
        ///
        /// IEX real time price represents trades on IEX only.Trades occur across over a dozen exchanges, so the last IEX price can be used to indicate the overall market price.       
        /// 15 minute delayed prices are from all markets using the Consolidated Tape.    
        /// This will not included pre or post market prices.
        /// </value>
        [JsonProperty("latestPrice")]
        public double? LatestPrice
        {
            get { return _latestPrice; }
            set { SetProperty(ref _latestPrice, value); }
        }

        string _latestSource;
        /// <summary>
        /// Gets or sets the latest source.
        /// </summary>
        /// <value>
        /// This will represent a human readable description of the source of latestPrice. 
        /// Possible values are "IEX real time price", "15 minute delayed price", "Close" or "Previous close"
        /// </value>
        [JsonProperty("latestSource")]
        public string LatestSource
        {
            get { return _latestSource; }
            set { SetProperty(ref _latestSource, value); }
        }

        string _latestTime;
        /// <summary>
        /// Gets or sets the latest time.
        /// </summary>
        /// <value>
        /// Refers to a human readable time of when latestPrice was last updated. 
        /// The format will vary based on latestSource is inteded to be displayed to a user. 
        /// Use latestUpdated for machine readable timestamp.
        /// </value>
        [JsonProperty("latestTime")]
        public string LatestTime
        {
            get { return _latestTime; }
            set { SetProperty(ref _latestTime, value); }
        }

        long? _latestUpdate;
        /// <summary>
        /// Gets or sets the latest update.
        /// </summary>
        /// <value>
        /// Refers to the machine readable epoch timestamp of when latestPrice was last updated. Represented as millisecond epoch time.
        /// </value>
        [JsonProperty("latestUpdate")]
        public long? LatestUpdate
        {
            get { return _latestUpdate; }
            set { SetProperty(ref _latestUpdate, value); }
        }
        /// <summary>
        /// Gets the latest update as a <c>DateTimeOffset</c>.
        /// </summary>
        /// <value>
        /// The latest update offset.
        /// </value>
        public DateTimeOffset? LatestUpdateOffset => LatestUpdate.HasValue ?
            (DateTimeOffset?)DateTimeOffset.FromUnixTimeMilliseconds(LatestUpdate.Value) : null;
        /// <summary>
        /// Gets the latest update as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The latest update date time.
        /// </value>
        public DateTime? LatestUpdateDateTime => LatestUpdateOffset?.DateTime;
             

        long? _latestVolume;
        /// <summary>
        /// Gets or sets the latest volume.
        /// </summary>
        /// <value>
        /// Use this to get the latest volume.
        /// 
        /// Refers to the latest total market volume of the stock across all markets. 
        /// This will be the most recent volume of the stock during trading hours, or it will be the total volume of the last available trading day.
        /// </value>
        [JsonProperty("latestVolume")]
        public long? LatestVolume
        {
            get { return _latestVolume; }
            set { SetProperty(ref _latestVolume, value); }
        }

        double? _iexRealtimePrice;
        /// <summary>
        /// Gets or sets the iex realtime price.
        /// </summary>
        /// <value>
        /// Refers to the price of the last trade on IEX.
        /// </value>
        [JsonProperty("iexRealtimePrice")]
        public double? IexRealtimePrice
        {
            get { return _iexRealtimePrice; }
            set { SetProperty(ref _iexRealtimePrice, value); }
        }

        long? _iexRealtimeSize;
        /// <summary>
        /// Gets or sets the size of the iex realtime.
        /// </summary>
        /// <value>
        /// Refers to the size of the last trade on IEX.
        /// </value>
        [JsonProperty("iexRealtimeSize")]
        public long? IexRealtimeSize
        {
            get { return _iexRealtimeSize; }
            set { SetProperty(ref _iexRealtimeSize, value); }
        }

        long? _iexLastUpdated;
        /// <summary>
        /// Gets or sets the iex last updated.
        /// </summary>
        /// <value>
        /// Refers to the last update time of iexRealtimePrice. Represented as millisecond epoch time.
        /// If the value is -1 or 0, IEX has not quoted the symbol in the trading day.
        /// </value>
        [JsonProperty("iexLastUpdated")]
        public long? IexLastUpdated
        {
            get { return _iexLastUpdated; }
            set { SetProperty(ref _iexLastUpdated, value); }
        }
        /// <summary>
        /// Gets the iex last updated value as a <c>DateTimeOffset</c>.
        /// </summary>
        /// <value>
        /// The iex last updated offest.
        /// If the value is null, IEX has not quoted the symbol in the trading day.
        /// </value>
        public DateTimeOffset? IexLastUpdatedOffest => (!IexLastUpdated.HasValue || IexLastUpdated.Value <= 0) 
            ? null : new DateTimeOffset?(DateTimeOffset.FromUnixTimeMilliseconds(IexLastUpdated.Value));
        /// <summary>
        /// Gets the iex last updated value as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The iex last updated date time.
        /// If the value is null, IEX has not quoted the symbol in the trading day.
        /// </value>
        public DateTime? IexLastUpdatedDateTime => IexLastUpdated <= 0 ? null : new DateTime?(IexLastUpdatedOffest.Value.DateTime);

        double? _delayedPrice;
        /// <summary>
        /// Gets or sets the delayed price.
        /// </summary>
        /// <value>
        /// Refers to the 15 minute delayed market price from the SIP during normal market hours 9:30 - 16:00 ET.
        /// </value>
        [JsonProperty("delayedPrice")]
        public double? DelayedPrice
        {
            get { return _delayedPrice; }
            set { SetProperty(ref _delayedPrice, value); }
        }

        long? _delayedPriceTime;
        /// <summary>
        /// Gets or sets the delayed price time.
        /// </summary>
        /// <value>
        /// Refers to the last update time of the delayed market price during normal market hours 9:30 - 16:00 ET.
        /// </value>
        [JsonProperty("delayedPriceTime")]
        public long? DelayedPriceTime
        {
            get { return _delayedPriceTime; }
            set { SetProperty(ref _delayedPriceTime, value); }
        }
        /// <summary>
        /// Gets the delayed price time as a <c>DateTimeOffest</c>.
        /// </summary>
        /// <value>
        /// The delayed price time offset.
        /// </value>
        public DateTimeOffset? DelayedPriceTimeOffset => DelayedPriceTime.HasValue ? 
            (DateTimeOffset?)DateTimeOffset.FromUnixTimeMilliseconds(DelayedPriceTime.Value) : null;
        /// <summary>
        /// Gets the delayed price time as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The delayed price time date time.
        /// </value>
        public DateTime? DelayedPriceTimeDateTime => DelayedPriceTimeOffset?.DateTime;

        double? _extendedPrice;
        /// <summary>
        /// Gets or sets the extended price.
        /// </summary>
        /// <value>
        /// Refers to the 15 minute delayed price outside normal market hours 0500 - 0930 ET and 1600 - 2000 ET. 
        /// This provides pre market and post market price. 
        /// This is purposefully separate from latestPrice so users can display the two prices separately.
        /// </value>
        [JsonProperty("extendedPrice")]
        public double? ExtendedPrice
        {
            get { return _extendedPrice; }
            set { SetProperty(ref _extendedPrice, value); }
        }

        double? _extendedChange;
        /// <summary>
        /// Gets or sets the extended change.
        /// </summary>
        /// <value>
        /// Refers to the price change between extendedPrice and latestPrice.
        /// </value>
        [JsonProperty("extendedChange")]
        public double? ExtendedChange
        {
            get { return _extendedChange; }
            set { SetProperty(ref _extendedChange, value); }
        }

        double? _extendedChangePercent;
        /// <summary>
        /// Gets or sets the extended change percent.
        /// </summary>
        /// <value>
        /// Refers to the price change percent between extendedPrice and latestPrice.
        /// </value>
        [JsonProperty("extendedChangePercent")]
        public double? ExtendedChangePercent
        {
            get { return _extendedChangePercent; }
            set { SetProperty(ref _extendedChangePercent, value); }
        }

        long? _extendedPriceTime;
        /// <summary>
        /// Gets or sets the extended price time.
        /// </summary>
        /// <value>
        /// Refers to the last update time of extendedPrice.
        /// </value>
        [JsonProperty("extendedPriceTime")]
        public long? ExtendedPriceTime
        {
            get { return _extendedPriceTime; }
            set { SetProperty(ref _extendedPriceTime, value); }
        }
        /// <summary>
        /// Gets the extended price time as a <c>DateTimeOffset</c>.
        /// </summary>
        /// <value>
        /// The extended price time offset.
        /// </value>
        public DateTimeOffset? ExtendedPriceTimeOffset => ExtendedPriceTime.HasValue ?
            (DateTimeOffset?)DateTimeOffset.FromUnixTimeMilliseconds(ExtendedPriceTime.Value) : null;
        /// <summary>
        /// Gets the extended price time as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The extended price time date time.
        /// </value>
        public DateTime? ExtendedPriceTimeDateTime => ExtendedPriceTimeOffset?.DateTime;

        double? _previousClose;
        /// <summary>
        /// Gets or sets the previous close.
        /// </summary>
        /// <value>
        /// Referes to the previous close value.
        /// </value>
        [JsonProperty("previousClose")]
        public double? PreviousClose
        {
            get { return _previousClose; }
            set { SetProperty(ref _previousClose, value); }
        }

        double?_change;
        /// <summary>
        /// Gets or sets the change.
        /// </summary>
        /// <value>
        /// Refers to the change in price between latestPrice and previousClose.
        /// </value>
        [JsonProperty("change")]
        public double? Change
        {
            get { return _change; }
            set { SetProperty(ref _change, value); }
        }

        double? _changePercent;
        /// <summary>
        /// Gets or sets the change percent.
        /// </summary>
        /// <value>
        /// Refers to the percent change in price between latestPrice and previousClose. 
        /// For example, a 5% change would be represented as 0.05.
        /// </value>
        [JsonProperty("changePercent")]
        public double? ChangePercent
        {
            get { return _changePercent; }
            set { SetProperty(ref _changePercent, value); }
        }

        double? _iexMarketPercent;
        /// <summary>
        /// Gets or sets the iex market percent.
        /// </summary>
        /// <value>
        /// Refers to IEX’s percentage of the market in the stock.
        /// </value>
        [JsonProperty("iexMarketPercent")]
        public double? IexMarketPercent
        {
            get { return _iexMarketPercent; }
            set { SetProperty(ref _iexMarketPercent, value); }
        }

        long? _iexVolume;
        /// <summary>
        /// Gets or sets the iex volume.
        /// </summary>
        /// <value>
        /// Refers to shares traded in the stock on IEX.
        /// </value>
        [JsonProperty("iexVolume")]
        public long? IexVolume
        {
            get { return _iexVolume; }
            set { SetProperty(ref _iexVolume, value); }
        }

        long? _avgTotalVolume;
        /// <summary>
        /// Gets or sets the average total volume.
        /// </summary>
        /// <value>
        /// Refers to the 30 day average volume.
        /// </value>
        [JsonProperty("avgTotalVolume")]
        public long? AvgTotalVolume
        {
            get { return _avgTotalVolume; }
            set { SetProperty(ref _avgTotalVolume, value); }
        }

        double? _iexBidPrice;
        /// <summary>
        /// Gets or sets the iex bid price.
        /// </summary>
        /// <value>
        /// Refers to the best bid price on IEX.
        /// </value>
        [JsonProperty("iexBidPrice")]
        public double? IexBidPrice
        {
            get { return _iexBidPrice; }
            set { SetProperty(ref _iexBidPrice, value); }
        }

        long? _iexBidSize;
        /// <summary>
        /// Gets or sets the size of the iex bid.
        /// </summary>
        /// <value>
        /// Refers to amount of shares on the bid on IEX.
        /// </value>
        [JsonProperty("iexBidSize")]
        public long? IexBidSize
        {
            get { return _iexBidSize; }
            set { SetProperty(ref _iexBidSize, value); }
        }

        double? _iexAskPrice;
        /// <summary>
        /// Gets or sets the iex ask price.
        /// </summary>
        /// <value>
        /// Refers to the best ask price on IEX.
        /// </value>
        [JsonProperty("iexAskPrice")]
        public double? IexAskPrice
        {
            get { return _iexAskPrice; }
            set { SetProperty(ref _iexAskPrice, value); }
        }

        long? _iexAskSize;
        /// <summary>
        /// Gets or sets the size of the iex ask.
        /// </summary>
        /// <value>
        /// Refers to amount of shares on the ask on IEX.
        /// </value>
        [JsonProperty("iexAskSize")]
        public long? IexAskSize
        {
            get { return _iexAskSize; }
            set { SetProperty(ref _iexAskSize, value); }
        }

        long? _marketCap;
        /// <summary>
        /// Gets or sets the market cap.
        /// </summary>
        /// <value>
        /// Is calculated in real time using latestPrice.
        /// </value>
        [JsonProperty("marketCap")]
        public long? MarketCap
        {
            get { return _marketCap; }
            set { SetProperty(ref _marketCap, value); }
        }

        double? _peRatio;
        /// <summary>
        /// Gets or sets the pe ratio.
        /// </summary>
        /// <value>
        /// Refers to the latest price to earnings ratio.
        /// </value>
        [JsonProperty("peRatio")]
        public double? PeRatio
        {
            get { return _peRatio; }
            set { SetProperty(ref _peRatio, value); }
        }

        double? _week52High;
        /// <summary>
        /// Gets or sets the week52 high.
        /// </summary>
        /// <value>
        /// Refers to the adjusted 52 week high.
        /// </value>
        [JsonProperty("week52High")]
        public double? Week52High
        {
            get { return _week52High; }
            set { SetProperty(ref _week52High, value); }
        }

        double? _week52Low;
        /// <summary>
        /// Gets or sets the week52 low.
        /// </summary>
        /// <value>
        /// Refers to the adjusted 52 week low.
        /// </value>
        [JsonProperty("week52Low")]
        public double? Week52Low
        {
            get { return _week52Low; }
            set { SetProperty(ref _week52Low, value); }
        }

        double? _ytdChange;
        /// <summary>
        /// Gets or sets the ytd change.
        /// </summary>
        /// <value>
        /// Refers to the price change percentage from start of year to previous close.
        /// </value>
        [JsonProperty("ytdChange")]
        public double? YtdChange
        {
            get { return _ytdChange; }
            set { SetProperty(ref _ytdChange, value); }
        }

        /// <summary>
        /// Creates a <c>Quote</c> object from a json string.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Deserialized <c>Quote</c> object.</returns>
        public static Quote FromJson(string json) => JsonConvert.DeserializeObject<Quote>(json, Converter.Settings);
    }
}
