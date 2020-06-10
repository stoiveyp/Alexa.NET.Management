using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Asr.AnnotationSet
{
    public class AnnotationSetMetadata
    {
        [JsonProperty("id",NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("annotationCount",NullValueHandling = NullValueHandling.Ignore)]
        public int AnnotationCount { get; set; }

        [JsonProperty("lastUpdatedTimestamp",NullValueHandling = NullValueHandling.Ignore),
        JsonConverter(typeof(Iso8601Converter))]
        public DateTime LastUpdatedTimestamp { get; set; }
    }
}
