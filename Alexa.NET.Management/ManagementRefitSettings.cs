using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Refit;

namespace Alexa.NET.Management
{
    public static class ManagementRefitSettings
    {
        public static RefitSettings Create()
        {
            return new RefitSettings
            {
                UrlParameterFormatter = new DefaultWithEnumUrlParamFormatter()
            };
        }

        public static RefitSettings Create(JsonSerializerSettings settings)
        {
            return new RefitSettings
            {
                UrlParameterFormatter = new DefaultWithEnumUrlParamFormatter(),
                ContentSerializer = new JsonContentSerializer(settings)
            };
        }
    }

    public class DefaultWithEnumUrlParamFormatter : DefaultUrlParameterFormatter
    {

        private static string ToEnumString(Type enumType, object type)
        {
            var name = Enum.GetName(enumType, type);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetTypeInfo().GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).FirstOrDefault();
            return enumMemberAttribute?.Value ?? type.ToString();
        }

        public override string Format(object value, ParameterInfo parameterInfo)
        {
            if (value is DateTime valueDt)
            {
                return valueDt.ToString("yyyy-MM-ddTHH:mm:ssZ");
            }

            if (value.GetType().IsEnum)
            {
                return ToEnumString(value.GetType(), value);
            }

            return base.Format(value, parameterInfo);
        }
    }
}
