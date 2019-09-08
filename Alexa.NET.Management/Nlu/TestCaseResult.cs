using Alexa.NET.Request;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Nlu.Evaluation
{
    public class TestCaseResult
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }

        public Intent Intent { get; set; }
    }
}