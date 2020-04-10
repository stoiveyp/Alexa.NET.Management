using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Audit
{
    public class SortDirectionUpperCaseConverter:StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }

            writer.WriteValue(value is SortDirection.Ascending ? "ASC" : "DESC");
        }
    }
}
