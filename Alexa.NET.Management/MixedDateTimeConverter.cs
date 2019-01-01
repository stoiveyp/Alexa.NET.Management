using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class MixedDateTimeConverter : Newtonsoft.Json.Converters.DateTimeConverterBase
    {
        static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }

        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.ValueType == typeof(DateTime))
            {
                return reader.Value;
            }

            if (reader.ValueType == typeof(long))
            {
                return UtcFromEpoch((long)reader.Value);
            }

            if (reader.ValueType == typeof(String))
            {
                if (long.TryParse(reader.Value.ToString(), out long number))
                {
                    return UtcFromEpoch(number);
                }

                return DateTime.Parse(reader.Value.ToString());
            }

            return UtcFromEpoch(((long)reader.Value));
        }

        private DateTime UtcFromEpoch(long epochTime)
        {
            return UnixEpoch.AddMilliseconds(epochTime);
        }
    }
}
