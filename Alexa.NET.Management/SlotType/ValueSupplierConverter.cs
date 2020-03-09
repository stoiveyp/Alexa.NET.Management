using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alexa.NET.Management.SlotType
{
    public class ValueSupplierConverter:JsonConverter<ValueSupplier>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, ValueSupplier value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override ValueSupplier ReadJson(JsonReader reader, Type objectType, ValueSupplier existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            // Load JObject from stream

            var jObject = JObject.Load(reader);

            var target = Mappings(jObject["type"].Value<string>());

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        private ValueSupplier Mappings(string value)
        {
            return value switch
            { 
                InlineValueSupplier.ValueSupplierType => (ValueSupplier)new InlineValueSupplier(),
                CatalogValueSupplier.ValueSupplierType => new CatalogValueSupplier(),
                _ => null
            };
        }
    }
}