using Newtonsoft.Json;

namespace Alexa.NET.Management.Manifest
{
    public class Permission
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}