using System;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Asr.AnnotationSet
{
    public class AudioAsset
    {
        [JsonProperty("downloadUrl")]
        public string DownloadUrl { get; set; }

        [JsonProperty("expiryTime")]
        public string ExpiryTime { get; set; }
    }
}