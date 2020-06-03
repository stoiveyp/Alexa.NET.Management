using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class Language
    {
        [JsonProperty("invocationName")]
        public string InvocationName { get; set; }

        [JsonProperty("intents")]
        public IntentType[] IntentTypes { get; set; }

        [JsonProperty("types",NullValueHandling = NullValueHandling.Ignore)]
        public SlotType[] SlotTypes { get; set; }

        [JsonProperty("modelConfiguration",NullValueHandling = NullValueHandling.Ignore)]
        public ModelConfiguration ModelConfiguration { get; set; }
    }
}
