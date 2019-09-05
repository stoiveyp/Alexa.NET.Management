using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.NluEvaluation
{
    internal class ReferenceTimestampConverter:IsoDateTimeConverter
    {
        public ReferenceTimestampConverter()
        {
            DateTimeFormat = "yyyy-MM-ddThh:mm:ss.fffZ";
        }
    }
}