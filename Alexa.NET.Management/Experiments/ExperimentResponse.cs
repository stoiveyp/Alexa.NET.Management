using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Experiments
{
    public class ExperimentResponse<T> where T : ExperimentBase
    {
        [JsonProperty("experiment", NullValueHandling = NullValueHandling.Ignore)]
        public T Experiment { get; set; }
    }
}
