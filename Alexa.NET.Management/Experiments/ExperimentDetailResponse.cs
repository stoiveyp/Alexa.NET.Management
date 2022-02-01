using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Experiments
{
    public class ExperimentDetailResponse
    {
        [JsonProperty("experiment",NullValueHandling = NullValueHandling.Ignore)]
        public ExperimentDetail Experiment { get; set; }
    }
}
