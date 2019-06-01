using Newtonsoft.Json;
using System;
using ZESoft.Mvvm.Models;

namespace IEX.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ZESoft.Mvvm.Models.ObservableObject" />
    public class Recommendation : ObservableObject
    {
        long? _consensusEndDate;
        /// <summary>
        /// Gets or sets the consensus end date value;
        /// </summary>
        /// <value>
        /// Date that represents the last date the consensus value was effective. A <c>null</c> value indicates the consensus value is considered current. Represented as millisecond epoch time.
        /// </value>
        [JsonProperty("consensusEndDate")]
        public long? ConsensusEndDate
        {
            get { return _consensusEndDate; }
            set { SetProperty(ref _consensusEndDate, value); }
        }
        /// <summary>
        /// Gets the consensus end date as a <c>DateTimeOffset</c>.
        /// </summary>
        /// <value>
        /// The consensus end date offset. A <c>null</c> value indicates the consensus value is considered current.
        /// </value>
        public DateTimeOffset? ConsensusEndDateOffset => ConsensusEndDate.HasValue ? new DateTimeOffset?(DateTimeOffset.FromUnixTimeMilliseconds(ConsensusEndDate.Value)) : null;
        /// <summary>
        /// Gets the consensus end date as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The consensus end date date time. A <c>null</c> value indicates the consensus value is considered current.
        /// </value>
        public DateTime? ConsensusEndDateDateTime => ConsensusEndDate.HasValue ? new DateTime?(ConsensusEndDateOffset.Value.DateTime) : null;

        long _consensusStartDate;
        /// <summary>
        /// Gets or sets the consensus start date value;
        /// </summary>
        /// <value>
        /// TDate that represents the earliest date the consensus value was effective. Represented as millisecond epoch time.
        /// </value>
        [JsonProperty("consensusStartDate")]
        public long ConsensusStartDate
        {
            get { return _consensusStartDate; }
            set { SetProperty(ref _consensusStartDate, value); }
        }
        /// <summary>
        /// Gets the consensus start date as a <c>DateTimeOffset</c>.
        /// </summary>
        /// <value>
        /// The consensus start date offset.
        /// </value>
        public DateTimeOffset ConsensusStartDateOffset => DateTimeOffset.FromUnixTimeMilliseconds(ConsensusStartDate);
        /// <summary>
        /// Gets the consensus start date as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The consensus start date date time.
        /// </value>
        public DateTime ConsensusStartDateDateTime => ConsensusStartDateOffset.DateTime;

        long _corporateActionsAppliedDate;
        /// <summary>
        /// Gets or sets the corporate actions applied date value;
        /// </summary>
        /// <value>
        /// Date through which corporate actions have been applied. Represented as millisecond epoch time.
        /// </value>
        [JsonProperty("corporateActionsAppliedDate")]
        public long CorporateActionsAppliedDate
        {
            get { return _corporateActionsAppliedDate; }
            set { SetProperty(ref _corporateActionsAppliedDate, value); }
        }
        /// <summary>
        /// Gets the corporate actions applied date as a <c>DateTimeOffset</c>.
        /// </summary>
        /// <value>
        /// The corporate actions applied date offset.
        /// </value>
        public DateTimeOffset CorporateActionsAppliedDateOffset => DateTimeOffset.FromUnixTimeMilliseconds(CorporateActionsAppliedDate);
        /// <summary>
        /// Gets the corporate actions applied date as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The corporate actions applied date date time.
        /// </value>
        public DateTime CorporateActionsAppliedDateDateTime => CorporateActionsAppliedDateOffset.DateTime;

        long _ratingBuy;
        /// <summary>
        /// Gets or sets the rating buy value.
        /// </summary>
        /// <value>
        /// Number of recommendations that fall into the Buy category.
        /// </value>
        [JsonProperty("ratingBuy")]
        public long RatingBuy
        {
            get { return _ratingBuy; }
            set { SetProperty(ref _ratingBuy, value); }
        }

        long _ratingHold;
        /// <summary>
        /// Gets or sets the rating hold value.
        /// </summary>
        /// <value>
        /// Number of recommendations that fall into the Hold category.
        /// </value>
        [JsonProperty("ratingHold")]
        public long RatingHold
        {
            get { return _ratingHold; }
            set { SetProperty(ref _ratingHold, value); }
        }

        long _ratingNone;
        /// <summary>
        /// Gets or sets the rating none value.
        /// </summary>
        /// <value>
        /// Number of brokers where no recommendation is available.
        /// </value>
        [JsonProperty("ratingNone")]
        public long RatingNone
        {
            get { return _ratingNone; }
            set { SetProperty(ref _ratingNone, value); }
        }

        long _ratingOverweight;
        /// <summary>
        /// Gets or sets the rating overweight value.
        /// </summary>
        /// <value>
        /// Number of recommendations that fall into the Overweight category.
        /// </value>
        [JsonProperty("ratingOverweight")]
        public long RatingOverweight
        {
            get { return _ratingOverweight; }
            set { SetProperty(ref _ratingOverweight, value); }
        }

        double _ratingScaleMark;
        /// <summary>
        /// Gets or sets the rating scale mark value.
        /// </summary>
        /// <value>
        /// Numeric value based on a standardized scale representing the consensus of broker recommendations.
        /// </value>
        [JsonProperty("ratingScaleMark")]
        public double RatingScaleMark
        {
            get { return _ratingScaleMark; }
            set { SetProperty(ref _ratingScaleMark, value); }
        }

        long _ratingSell;
        /// <summary>
        /// Gets or sets the rating sell value.
        /// </summary>
        /// <value>
        /// Number of recommendations that fall into the Sell category.
        /// </value>
        [JsonProperty("ratingSell")]
        public long RatingSell
        {
            get { return _ratingSell; }
            set { SetProperty(ref _ratingSell, value); }
        }

        long _ratingUnderweight;
        /// <summary>
        /// Gets or sets the rating underweight value.
        /// </summary>
        /// <value>
        /// Number of recommendations that fall into the Underweight category.
        /// </value>
        [JsonProperty("ratingUnderweight")]
        public long RatingUnderweight
        {
            get { return _ratingUnderweight; }
            set { SetProperty(ref _ratingUnderweight, value); }
        }

        /// <summary>
        /// Creates a <c>Recommendation</c> object from the given json string.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Deserialized <c>Recommendation</c> object.</returns>
        public static Recommendation FromJson(string json) => JsonConvert.DeserializeObject<Recommendation>(json, IEX.Net.Converter.Settings);
    }
}
