using Newtonsoft.Json;
using System;
using ZESoft.Mvvm.Models;

namespace IEX.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ZESoft.Mvvm.Models.ObservableObject" />
    public class PriceTarget : ObservableObject
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

        DateTime _updatedDate;
        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>
        /// The price target update date.
        /// </value>
        [JsonProperty("updatedDate")]
        public DateTime UpdatedDate
        {
            get { return _updatedDate; }
            set { SetProperty(ref _updatedDate, value); }
        }

        double _priceTargetAverage;
        /// <summary>
        /// Gets or sets the average price target.
        /// </summary>
        /// <value>
        /// The average price target.
        /// </value>
        [JsonProperty("priceTargetAverage")]
        public double PriceTargetAverage
        {
            get { return _priceTargetAverage; }
            set { SetProperty(ref _priceTargetAverage, value); }
        }

        double _priceTargetHigh;
        /// <summary>
        /// Gets or sets the high price target.
        /// </summary>
        /// <value>
        /// The high price target.
        /// </value>
        [JsonProperty("priceTargetHigh")]
        public double PriceTargetHigh
        {
            get { return _priceTargetHigh; }
            set { SetProperty(ref _priceTargetHigh, value); }
        }

        double _priceTargetLow;
        /// <summary>
        /// Gets or sets the low price target.
        /// </summary>
        /// <value>
        /// The low price target.
        /// </value>
        [JsonProperty("priceTargetLow")]
        public double PriceTargetLow
        {
            get { return _priceTargetLow; }
            set { SetProperty(ref _priceTargetLow, value); }
        }

        int _numberOfAnalysts;
        /// <summary>
        /// Gets or sets the number of analysts.
        /// </summary>
        /// <value>
        /// The number of analysts.
        /// </value>
        [JsonProperty("numberOfAnalysts")]
        public int NumberOfAnalysts
        {
            get { return _numberOfAnalysts; }
            set { SetProperty(ref _numberOfAnalysts, value); }
        }
    }
}
