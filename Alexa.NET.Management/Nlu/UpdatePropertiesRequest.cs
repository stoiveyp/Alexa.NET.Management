using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Nlu.AnnotationSet
{
    internal class UpdatePropertiesRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
