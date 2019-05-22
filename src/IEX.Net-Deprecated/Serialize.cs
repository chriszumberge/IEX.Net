using IEX.Net.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEX.Net
{
    public static class Serialize
    {
        public static string ToJson(this Company self) => JsonConvert.SerializeObject(self, Converters.Converter.Settings);
        public static string ToJson(this Dividend self) => JsonConvert.SerializeObject(self, Converters.Converter.Settings);
        public static string ToJson(this Symbol self) => JsonConvert.SerializeObject(self, Converters.Converter.Settings);
    }
}
