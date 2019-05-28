using Newtonsoft.Json;
using System;
using ZESoft.Mvvm.Models;

namespace IEX.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ZESoft.Mvvm.Models.ObservableObject" />
    public class MarketVolume : ObservableObject
    {
        string _mic;
        /// <summary>
        /// Gets or sets the mic.
        /// </summary>
        /// <value>
        /// Refers to the Market Identifier Code (MIC).
        /// </value>
        [JsonProperty("mic")]
        public string Mic
        {
            get { return _mic; }
            set { SetProperty(ref _mic, value); }
        }

        string _tapeId;
        /// <summary>
        /// Gets or sets the tape identifier.
        /// </summary>
        /// <value>
        /// Refers to the tape id of the venue.
        /// </value>
        [JsonProperty("tapeId")]
        public string TapeId
        {
            get { return _tapeId; }
            set { SetProperty(ref _tapeId, value); }
        }

        string _venueName;
        /// <summary>
        /// Gets or sets the name of the venue.
        /// </summary>
        /// <value>
        /// Refers to name of the venue defined by IEX.
        /// </value>
        [JsonProperty("venueName")]
        public string VenueName
        {
            get { return _venueName; }
            set { SetProperty(ref _venueName, value); }
        }

        long _volume;
        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>
        /// Refers to the amount of traded shares reported by the venue.
        /// </value>
        [JsonProperty("volume")]
        public long Volume
        {
            get { return _volume; }
            set { SetProperty(ref _volume, value); }
        }

        long _tapeA;
        /// <summary>
        /// Gets or sets the tape a.
        /// </summary>
        /// <value>
        /// Refers to the amount of Tape A traded shares reported by the venue.
        /// </value>
        [JsonProperty("tapeA")]
        public long TapeA
        {
            get { return _tapeA; }
            set { SetProperty(ref _tapeA, value); }
        }

        long _tapeB;
        /// <summary>
        /// Gets or sets the tape b.
        /// </summary>
        /// <value>
        /// Refers to the amount of Tape B traded shares reported by the venue.
        /// </value>
        [JsonProperty("tapeB")]
        public long TapeB
        {
            get { return _tapeB; }
            set { SetProperty(ref _tapeB, value); }
        }

        long _tapeC;
        /// <summary>
        /// Gets or sets the tape c.
        /// </summary>
        /// <value>
        /// Refers to the amount of Tape C traded shares reported by the venue.
        /// </value>
        [JsonProperty("tapeC")]
        public long TapeC
        {
            get { return _tapeC; }
            set { SetProperty(ref _tapeC, value); }
        }

        double _marketPercent;
        /// <summary>
        /// Gets or sets the market percent.
        /// </summary>
        /// <value>
        /// Refers to the venue’s percentage of shares traded in the market.
        /// </value>
        [JsonProperty("marketPercent")]
        public double MarketPercent
        {
            get { return _marketPercent; }
            set { SetProperty(ref _marketPercent, value); }
        }

        long _lastUpdated;
        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        /// <value>
        /// Refers to the last update time of the data. Represented as millisecond epoch time.
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
        /// Creates a <c>MarketVolume</c> object from a json string.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Deserialized <c>MarketVolume</c> object.</returns>
        public static MarketVolume FromJson(string json) => JsonConvert.DeserializeObject<MarketVolume>(json, Converter.Settings);
    }
}
