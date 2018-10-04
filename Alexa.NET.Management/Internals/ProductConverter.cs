using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Alexa.NET.Management.InSkillProduct;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alexa.NET.Management.Internals
{
    public class ProductConverter : JsonConverter
    {
        private Product Mappings(string type)
        {
            if (type == Product.EntitlementType)
            {
                return new EntitlementProduct();
            }

            if (type == Product.SubscriptionType)
            {
                return new SubscriptionProduct();
            }

            if (type == Product.ConsumableType)
            {
                return new ConsumableProduct();
            }

            throw new InvalidOperationException("Unknown type: " + type);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream

            var jObject = JObject.Load(reader);

            var target = Mappings(jObject["type"].Value<string>());

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(Product));
        }
    }
}
