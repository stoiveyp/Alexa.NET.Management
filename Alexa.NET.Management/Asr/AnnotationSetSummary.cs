using System;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Asr.AnnotationSet
{
    public class AnnotationSetSummary
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("annotationCount")]
        public int AnnotationCount { get; set; }

        [JsonProperty("lastUpdatedTimestamp"),JsonConverter(typeof(Iso8601Converter))]
        public DateTime LastUpdatedTimestamp { get; set; }
    }
}