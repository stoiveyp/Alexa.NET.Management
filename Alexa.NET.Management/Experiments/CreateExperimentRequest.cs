using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Experiments
{
    public class CreateExperimentRequest
    {
        public CreateExperimentRequest(){}

        public CreateExperimentRequest(Experiment experiment)
        {
            Experiment = experiment;
        }

        [JsonProperty("experiment")]
        public Experiment Experiment { get; set; }
    }
}
