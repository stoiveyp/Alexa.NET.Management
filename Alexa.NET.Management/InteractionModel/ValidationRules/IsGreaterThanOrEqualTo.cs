using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel.ValidationRules
{
    public class IsGreaterThanOrEqualTo : DialogSlotValidation
    {
        public const string ValidationType = "isGreaterThanOrEqualTo";
        public override string Type => ValidationType;

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}