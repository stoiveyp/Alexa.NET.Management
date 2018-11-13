using System;
using System.Reflection;
using Alexa.NET.Management.InteractionModel.ValidationRules;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alexa.NET.Management.InteractionModel
{
    public class DialogSlotValidationConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            var jObject = JObject.Load(reader);
            var componentType = jObject.Value<string>("type");
            object target = GetComponent(componentType);
            if (target == null)
            {
                throw new ArgumentOutOfRangeException($"DialogSlot validation type {componentType} not supported");
            }

            serializer.Populate(jObject.CreateReader(), target);

            return target;

        }

        private DialogSlotValidation GetComponent(string type)
        {
            switch (type)
            {
                case HasEntityResolutionMatch.ValidationType:
                    return new HasEntityResolutionMatch();
                case IsInSet.ValidationType:
                    return new IsInSet();
                case IsNotInSet.ValidationType:
                    return new IsNotInSet();
                case IsLessThan.ValidationType:
                    return new IsLessThan();
                case IsLessThanOrEqualTo.ValidationType:
                    return new IsLessThanOrEqualTo();
                case IsGreaterThan.ValidationType:
                    return new IsGreaterThan();
                case IsGreaterThanOrEqualTo.ValidationType:
                    return new IsGreaterThanOrEqualTo();
                default:
                    return null;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().IsSubclassOf(typeof(DialogSlotValidation));
        }
    }
}