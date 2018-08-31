using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEX.Net.Models
{
    public partial class Dividend
    {
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

        [JsonProperty("type")]
        public DividendTypeEnum Type { get; set; }

        [JsonProperty("qualified")]
        public DividendQualified Qualified { get; set; }

        [JsonProperty("indicated")]
        public string Indicated { get; set; }
    }

    public enum DividendQualified { Q };

    public enum DividendTypeEnum { DividendIncome };

    public partial class Dividend
    {
        public static Dividend[] FromJson(string json) => JsonConvert.DeserializeObject<Dividend[]>(json, Converters.Converter.Settings);
    }
}
