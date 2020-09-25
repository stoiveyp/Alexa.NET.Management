using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class ExtensionInterface:CustomApiInterface
    {
        [JsonProperty("type")]
        public override string Type => "ALEXA_EXTENSION";

        [JsonProperty("requestedExtensions")]
        public ExtensionUri[] RequestedExtensions { get; set; }

        [JsonProperty("autoInitializedExtensions")]
        public InitalisedExtensionUri[] AutoInitializedExtensions { get; set; }
    }
}
