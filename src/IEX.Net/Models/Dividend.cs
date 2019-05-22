using Newtonsoft.Json;
using System;

namespace IEX.Net
{
    public class Dividend : ObservableObject
    {
        string _symbol;
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("exDate")]
        public DateTimeOffset ExDate { get; set; }

        [JsonProperty("paymentDate")]
        public DateTimeOffset PaymentDate { get; set; }

        [JsonProperty("recordDate")]
        public DateTimeOffset RecordDate { get; set; }

        [JsonProperty("declaredDate")]
        public DateTimeOffset DeclaredDate { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        public static Dividend FromJson(string json) => JsonConvert.DeserializeObject<Dividend>(json, Converter.Settings);
    }
}
