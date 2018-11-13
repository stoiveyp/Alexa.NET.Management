using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel.ValidationRules
{
    public class IsGreaterThan : DialogSlotValidation
    {
        public const string ValidationType = "isGreaterThan";
        public override string Type => ValidationType;

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}