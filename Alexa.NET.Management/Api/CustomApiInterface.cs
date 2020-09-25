using Alexa.NET.Management.Internals;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    [JsonConverter(typeof(CustomApiInterfaceConverter))]
    public abstract class CustomApiInterface
    {
        [JsonProperty("type")]
        public abstract string Type { get; }
    }
}