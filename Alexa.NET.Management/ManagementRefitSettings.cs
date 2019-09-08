using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Nlu.Evaluation;
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
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetTypeInfo().GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            return enumMemberAttribute.Value;
        }

        public override string Format(object value, ParameterInfo parameterInfo)
        {
            if (value is SkillStage stage)
            {
                return ToEnumString(typeof(SkillStage), stage);
            }

            if (value is SortDirection sortDirection)
            {
                return ToEnumString(typeof(SortDirection), sortDirection);
            }

            if (value is TestCaseStatus testCaseStatus)
            {
                return ToEnumString(typeof(TestCaseStatus), testCaseStatus);
            }

            if (value is EvaluationSortField sortField)
            {
                return ToEnumString(typeof(EvaluationSortField), sortField);
            }

            return base.Format(value, parameterInfo);
        }
    }
}
