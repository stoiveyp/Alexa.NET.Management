using Alexa.NET.Management.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Nlu.Evaluation
{
    public class CreateEvaluationRequest
    {
        public CreateEvaluationRequest() { }

        public CreateEvaluationRequest(SkillStage stage, string locale, string annotationId)
        {
            Stage = stage;
            Locale = locale;
            Source = new EvaluationSource(annotationId);
        }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("stage"), JsonConverter(typeof(StringEnumConverter))]
        public SkillStage Stage { get; set; }

        [JsonProperty("source")]
        public EvaluationSource Source { get; set; }
    }
}
