using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Skills
{
    public class SimulationSession
    {
        public SimulationSession() { }

        public SimulationSession(SimulationSessionMode mode)
        {
            Mode = mode;
        }

        [JsonProperty("mode"),JsonConverter(typeof(StringEnumConverter))]
        public SimulationSessionMode Mode { get; set; }

        public static SimulationSession Default => new SimulationSession(SimulationSessionMode.DEFAULT);
        public static SimulationSession ForceNewSession => new SimulationSession(SimulationSessionMode.FORCE_NEW_SESSION);
    }
}
