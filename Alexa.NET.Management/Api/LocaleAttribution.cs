using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class LocaleAttribution
    {
        [JsonProperty("answerAttribution",NullValueHandling = NullValueHandling.Ignore)]
        public string AnswerAttribution { get; set; }
    }
}