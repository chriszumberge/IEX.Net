using Newtonsoft.Json;
using System;
using ZESoft.Mvvm.Models;

namespace IEX.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ZESoft.Mvvm.Models.ObservableObject" />
    public class SectorPerformance : ObservableObject
    {
        string _type;
        /// <summary>
        /// Gets or sets the type value. Should always be <c>sector</c>.
        /// </summary>
        /// <value>
        /// The type of performance data return.
        /// </value>
        [JsonProperty("type")]
        public string Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
        }

        string _name;
        /// <summary>
        /// Gets or sets the name value.
        /// </summary>
        /// <value>
        /// TThe name of the sector.
        /// </value>
        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        double _performance;
        /// <summary>
        /// Gets or sets the performance value;
        /// </summary>
        /// <value>
        /// The change percent of the sector for the trading day.
        /// </value>
        [JsonProperty("performance")]
        public double Performance
        {
            get { return _performance; }
            set { SetProperty(ref _performance, value); }
        }

        long _lastUpdated;
        /// <summary>
        /// Gets or sets the last updated value.
        /// </summary>
        /// <value>
        /// Last updated time of the performance metric represented as millisecond epoch.
        /// </value>
        [JsonProperty("lastUpdated")]
        public long LastUpdated
        {
            get { return _lastUpdated; }
            set { SetProperty(ref _lastUpdated, value); }
        }
        /// <summary>
        /// Gets the last updated value as a <c>DateTimeOffset</c> object.
        /// </summary>
        /// <value>
        /// The last updated date time offest value.
        /// </value>
        public DateTimeOffset LastUpdatedOffest => DateTimeOffset.FromUnixTimeMilliseconds(LastUpdated);
        /// <summary>
        /// Gets the last updated value as a <c>DateTime</c> object.
        /// </summary>
        /// <value>
        /// The last updated date time value.
        /// </value>
        public DateTime LastUpdatedDateTime => LastUpdatedOffest.DateTime;

        /// <summary>
        /// Creates a <c>SectorPerformance</c> object from a json string.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Deserialized <c>SectorPerformance</c> object.</returns>
        public static SectorPerformance FromJson(string json) => JsonConvert.DeserializeObject<SectorPerformance>(json, Converter.Settings);
    }
}
