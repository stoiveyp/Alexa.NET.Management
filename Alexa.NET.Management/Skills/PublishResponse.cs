using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Skills
{
    public class PublishResponse
    {
        [JsonProperty("publishesAt")]
        public DateTime PublishesAt { get; set; }

        [JsonProperty("status"), JsonConverter(typeof(StringEnumConverter))]
        public PublishStatus Status { get; set; }
    }
}