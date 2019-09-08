using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Nlu.Evaluation
{
    public class EvaluationStatusWithLinks:EvaluationStatus
    {
        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }
    }
}