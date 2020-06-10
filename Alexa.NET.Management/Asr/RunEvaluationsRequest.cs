using Newtonsoft.Json;

namespace Alexa.NET.Management.Asr.Evaluations
{
    public class RunEvaluationsRequest
    {
        [JsonProperty("annotationSetId")]
        public string AnnotationSetId { get; set; }

        [JsonProperty("skill")]
        public SkillInformation Skill { get; set; }
    }
}
