using Newtonsoft.Json;

namespace IEX.Net
{
    public static class Serialize
    {
        public static string ToJson(this Company self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this Dividend self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this Quote self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
