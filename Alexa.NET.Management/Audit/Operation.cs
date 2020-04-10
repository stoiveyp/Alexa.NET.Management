using Newtonsoft.Json;

namespace Alexa.NET.Management.Audit
{
    public class Operation
    {
        public Operation() { }

        public Operation(string name, string version)
        {
            Name = name;
            Version = version;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}