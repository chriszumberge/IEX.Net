using Newtonsoft.Json;
using System;
using ZESoft.Mvvm.Models;

namespace IEX.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ZESoft.Mvvm.Models.ObservableObject" />
    public class News : ObservableObject
    {
        long _datetime;
        /// <summary>
        /// Gets or sets the Datetime.
        /// </summary>
        /// <value>
        /// Millisecond epoch of time of article.
        /// </value>
        [JsonProperty("datetime")]
        public long Datetime
        {
            get { return _datetime; }
            set { SetProperty(ref _datetime, value); }
        }
        /// <summary>
        /// Gets the published date as a <c>DateTimeOffset</c>.
        /// </summary>
        /// <value>
        /// The published date offest.
        /// </value>
        public DateTimeOffset PublishedDateOffest => DateTimeOffset.FromUnixTimeMilliseconds(Datetime);
        /// <summary>
        /// Gets the published date as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The published date date time.
        /// </value>
        public DateTime PublishedDateDateTime => PublishedDateOffest.DateTime;


        string _headline;
        /// <summary>
        /// Gets or sets the headline.
        /// </summary>
        /// <value>
        /// The headline of the article.
        /// </value>
        [JsonProperty("headline")]
        public string Headline
        {
            get { return _headline; }
            set { SetProperty(ref _headline, value); }
        }

        string _source;
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// Source of the news article. Make sure to always attribute the source.
        /// </value>
        [JsonProperty("source")]
        public string Source
        {
            get { return _source; }
            set { SetProperty(ref _source, value); }
        }

        Uri _url;
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// URL to IEX Cloud for associated news image. 
        /// Note: You will need to append your token before calling.
        /// </value>
        /// <remarks>
        /// You will need to append your token before calling.
        /// </remarks>
        [JsonProperty("url")]
        public Uri Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        string _summary;
        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>
        /// The summary of the article.
        /// </value>
        [JsonProperty("summary")]
        public string Summary
        {
            get { return _summary; }
            set { SetProperty(ref _summary, value); }
        }

        string _related;
        /// <summary>
        /// Gets or sets the related.
        /// </summary>
        /// <value>
        /// Comma-delimited list of tickers associated with this news article.
        /// </value>
        /// <remarks>
        /// Not all tickers are available on the API. 
        /// Make sure to check against available ref-data
        /// </remarks>
        [JsonProperty("related")]
        public string Related
        {
            get { return _related; }
            set { SetProperty(ref _related, value); }
        }

        Uri _image;
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// URL to IEX Cloud for associated news image.
        /// </value>
        /// <remarks>
        /// You will need to append your token before calling.
        /// </remarks>
        [JsonProperty("image")]
        public Uri Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        string _lang;
        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// Language of the source article.
        /// </value>
        [JsonProperty("lang")]
        public string Language
        {
            get { return _lang; }
            set { SetProperty(ref _lang, value); }
        }

        bool _hasPaywall;
        /// <summary>
        /// Gets or sets a value indicating whether this news source has a paywall.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has paywall; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("hasPaywall")]
        public bool HasPaywall
        {
            get { return _hasPaywall; }
            set { SetProperty(ref _hasPaywall, value); }
        }

        /// <summary>
        /// Creates a <c>News</c> object from a json string.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Deserialized <c>News</c> object.</returns>
        public static News FromJson(string json) => JsonConvert.DeserializeObject<News>(json, Converter.Settings);
    }
}
