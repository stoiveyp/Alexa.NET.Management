using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel.ValidationRules
{
    public class IsLessThan : DialogSlotValidation
    {
        public const string ValidationType = "isLessThan";
        public override string Type => ValidationType;

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}