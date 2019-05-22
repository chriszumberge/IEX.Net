using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace IEX.Net.Converters
{
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                DividendQualifiedConverter.Singleton,
                DividendTypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
