using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.NET.Management.InteractionModel
{
    public class IntentPrompt
    {
        [JsonProperty("confirmation", NullValueHandling = NullValueHandling.Ignore)]
        public string ConfirmationPrompt { get; set; }
    }
}
