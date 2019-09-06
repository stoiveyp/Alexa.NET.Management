using System;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Nlu.AnnotationSet
{
    public class AnnotationSetProperties
    {
        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("numberOfEntries")]
        public int NumberOfEntries { get; set; }

        [JsonProperty("updatedTimestamp")]
        public DateTime UpdatedTimestamp { get; set; }

        [JsonProperty("annotationId")]
        public string AnnotationId { get; set; }
    }
}