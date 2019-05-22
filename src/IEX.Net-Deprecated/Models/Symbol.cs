using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEX.Net.Models
{
    public partial class Symbol
    {
        [JsonProperty("symbol")]
        public string SymbolSymbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }
    }

    public partial class Symbol
    {
        public static Symbol[] FromJson(string json) => JsonConvert.DeserializeObject<Symbol[]>(json, Converters.Converter.Settings);
    }

}
