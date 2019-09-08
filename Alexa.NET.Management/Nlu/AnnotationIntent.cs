using System.Collections.Generic;
using System.Data.Common;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Nlu.AnnotationSet
{
    public class AnnotationIntent
    {
        public AnnotationIntent() { }

        public AnnotationIntent(string name, Dictionary<string, SlotValue> slots)
        {
            Name = name;
            Slots = slots;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slots",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, SlotValue> Slots { get; set; }
    }

    public class SlotValue
    {
        public SlotValue() { }

        public SlotValue(string value)
        {
            Value = value;
        }

        [JsonProperty("value")]
        public string Value { get; set; }

        public static implicit operator SlotValue(string slot)
        {
            return new SlotValue(slot);
        }
    }
}