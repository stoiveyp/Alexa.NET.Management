using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Skills
{
    public class SubmitRequest
    {
        [JsonProperty("publicationMethod"),JsonConverter(typeof(StringEnumConverter))]
        public PublicationMethod PublicationMethod { get; set; }
    }
}
