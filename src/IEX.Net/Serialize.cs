using Newtonsoft.Json;

namespace IEX.Net
{
    public static class Serialize
    {
        public static string ToJson(this Company self) => SerializeObject(self);
        public static string ToJson(this Dividend self) => SerializeObject(self);
        public static string ToJson(this MarketVolume self) => SerializeObject(self);
        public static string ToJson(this News self) => SerializeObject(self);
        public static string ToJson(this Quote self) => SerializeObject(self);
        public static string ToJson(this Recommendation self) => SerializeObject(self);
        public static string ToJson(this SectorPerformance self) => SerializeObject(self);

        static string SerializeObject<T>(T self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
