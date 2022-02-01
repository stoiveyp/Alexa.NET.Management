using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Experiments
{
    public class ExperimentRequest<T> where T:ExperimentBase
    {
        public ExperimentRequest() { }

        public ExperimentRequest(T experiment)
        {
            Experiment = experiment;
        }

        [JsonProperty("experiment")]
        public T Experiment { get; set; }
    }
}
