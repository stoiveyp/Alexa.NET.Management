using System.Reflection;
using Alexa.NET.Management.Api;
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
    }

    public class DefaultWithEnumUrlParamFormatter : DefaultUrlParameterFormatter
    {
        public override string Format(object value, ParameterInfo parameterInfo)
        {
            if (value is SkillStage stage)
            {
                if (stage == SkillStage.Development)
                {
                    return "development";
                }

                if (stage == SkillStage.Live)
                {
                    return "live";
                }
            }

            if (value is SortDirection sortDirection)
            {
                if (sortDirection == SortDirection.Ascending)
                {
                    return "asc";
                }

                if (sortDirection == SortDirection.Descending)
                {
                    return "desc";
                }
            }

            return base.Format(value, parameterInfo);
        }
    }
}
