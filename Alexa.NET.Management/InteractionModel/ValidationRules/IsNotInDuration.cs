using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel.ValidationRules
{
    public class IsNotInDuration : DialogSlotValidation
    {
        public const string ValidationType = "isNotInDuration";
        public override string Type => ValidationType;

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }
    }
}