using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Management.Nlu.AnnotationSet;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Nlu.Evaluation
{
    public class EvaluationResults
    {
        [JsonProperty("testCases")]
        public TestCase[] TestCases { get; set; }

        [JsonProperty("totalFailed")]
        public int TotalFailed { get; set; }

        [JsonProperty("paginationContext")]
        public PaginationContextWithTotalCount PaginationContext { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }
    }

    public class TestCase
    {
        [JsonProperty("status"),
        JsonConverter(typeof(StringEnumConverter))]
        public TestCaseStatus Status { get; set; }

        [JsonProperty("inputs")]
        public AnnotationInputs Inputs { get; set; }

        [JsonProperty("actual")]
        public TestCaseResult Actual { get; set; }

        [JsonProperty("expected")]
        public TestCaseResult Expected { get; set; }
    }
}
