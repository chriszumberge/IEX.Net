using IEX.Net.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEX.Net.Converters
{
    internal class DividendTypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DividendTypeEnum) || t == typeof(DividendTypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Dividend income")
            {
                return DividendTypeEnum.DividendIncome;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DividendTypeEnum)untypedValue;
            if (value == DividendTypeEnum.DividendIncome)
            {
                serializer.Serialize(writer, "Dividend income");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly DividendTypeEnumConverter Singleton = new DividendTypeEnumConverter();
    }
}
