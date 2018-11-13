using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel.ValidationRules
{
    public class IsInDuration : DialogSlotValidation
    {
        public const string ValidationType = "isInDuration";
        public override string Type => ValidationType;

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }
    }
}