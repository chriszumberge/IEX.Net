using IEX.Net.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEX.Net.Converters
{
    internal class DividendQualifiedConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DividendQualified) || t == typeof(DividendQualified?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Q")
            {
                return DividendQualified.Q;
            }
            throw new Exception("Cannot unmarshal type Qualified");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DividendQualified)untypedValue;
            if (value == DividendQualified.Q)
            {
                serializer.Serialize(writer, "Q");
                return;
            }
            throw new Exception("Cannot marshal type Qualified");
        }

        public static readonly DividendQualifiedConverter Singleton = new DividendQualifiedConverter();
    }
}
