using Newtonsoft.Json;
using System;
using ZESoft.Mvvm.Models;

namespace IEX.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ZESoft.Mvvm.Models.ObservableObject" />
    public class Dividend : ObservableObject
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

        DateTimeOffset _exDate;
        /// <summary>
        /// Gets or sets the ex date.
        /// </summary>
        /// <value>
        /// Refers to the dividend ex-date
        /// </value>
        [JsonProperty("exDate")]
        public DateTimeOffset ExDate
        {
            get { return _exDate; }
            set { SetProperty(ref _exDate, value); }
        }
        /// <summary>
        /// Gets the ex date as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The ex date date time.
        /// </value>
        public DateTime ExDateTime => ExDate.DateTime;

        DateTimeOffset _paymentDate;
        /// <summary>
        /// Gets or sets the payment date.
        /// </summary>
        /// <value>
        /// Refers to the payment date
        /// </value>
        [JsonProperty("paymentDate")]
        public DateTimeOffset PaymentDate
        {
            get { return _paymentDate; }
            set { SetProperty(ref _paymentDate, value); }
        }
        /// <summary>
        /// Gets the payment date as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The payment date time.
        /// </value>
        public DateTime PaymentDateTime => PaymentDate.DateTime;

        DateTimeOffset _recordDate;
        /// <summary>
        /// Gets or sets the record date.
        /// </summary>
        /// <value>
        /// Refers to the dividend record date.
        /// </value>
        [JsonProperty("recordDate")]
        public DateTimeOffset RecordDate
        {
            get { return _recordDate; }
            set { SetProperty(ref _recordDate, value); }
        }
        /// <summary>
        /// Gets the record date as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The record date time.
        /// </value>
        public DateTime RecordDateTime => RecordDate.DateTime;

        DateTimeOffset _declaredDate;
        /// <summary>
        /// Gets or sets the declared date.
        /// </summary>
        /// <value>
        /// Refers to the dividend declaration date.
        /// </value>
        [JsonProperty("declaredDate")]
        public DateTimeOffset DeclaredDate
        {
            get { return _declaredDate; }
            set { SetProperty(ref _declaredDate, value); }
        }
        /// <summary>
        /// Gets the declared date as a <c>DateTime</c>.
        /// </summary>
        /// <value>
        /// The declared date time.
        /// </value>
        public DateTime DeclaredDateTime => DeclaredDate.DateTime;

        double _amount;
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// Refers to the payment amount.
        /// </value>
        [JsonProperty("amount")]
        public double Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }

        // TODO into enum
        string _flag;
        /// <summary>
        /// Gets or sets the flag.
        /// </summary>
        /// <value>
        /// Rype of dividend event.
        /// </value>
        [JsonProperty("flag")]
        public string Flag
        {
            get { return _flag; }
            set { SetProperty(ref _flag, value); }
        }

        string _currency;
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// Currency of the dividend.
        /// </value>
        [JsonProperty("currency")]
        public string Currency
        {
            get { return _currency; }
            set { SetProperty(ref _currency, value); }
        }

        string _description;
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// Description of the dividend event.
        /// </value>
        [JsonProperty("description")]
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        // TODO into enum
        string _frequency;
        /// <summary>
        /// Gets or sets the frequency.
        /// </summary>
        /// <value>
        /// Frequency of the dividend.
        /// </value>
        [JsonProperty("frequency")]
        public string Frequency
        {
            get { return _frequency; }
            set { SetProperty(ref _frequency, value); }
        }

        /// <summary>
        /// Creates a <c>Dividend</c> object from a json string.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Deserialized <c>Dividend</c> object.</returns>
        public static Dividend FromJson(string json) => JsonConvert.DeserializeObject<Dividend>(json, Converter.Settings);
    }
}
