using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management
{
    internal class Iso8601Converter:IsoDateTimeConverter
    {
        public Iso8601Converter()
        {
            DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
        }
    }
}