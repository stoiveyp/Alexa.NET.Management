using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Nlu.AnnotationSet
{
    public class Annotation
    {
        public Annotation()
        {
            Inputs = new AnnotationInputs();
        }

        public Annotation(string utterance, DateTime timestamp, string intent, Dictionary<string,SlotValue> slots)
        {
            Inputs = new AnnotationInputs
            {
                Utterance = utterance,
                ReferenceTimestamp = timestamp
            };
            Expected = new[]{new AnnotationExpected
            {
                Intent = new AnnotationIntent(intent, slots)
            }};
        }

        [JsonProperty("inputs")]
        public AnnotationInputs Inputs { get; set; }

        [JsonProperty("expected")]
        public AnnotationExpected[] Expected { get; set; }
    }
}