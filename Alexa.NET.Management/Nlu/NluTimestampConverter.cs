using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Nlu
{
    internal class NluTimestampConverter:IsoDateTimeConverter
    {
        public NluTimestampConverter()
        {
            DateTimeFormat = "yyyy-MM-ddThh:mm:ss.fffZ";
        }
    }
}