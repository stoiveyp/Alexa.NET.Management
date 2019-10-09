using System;
using Alexa.NET.Management.Api;
using Alexa.NET.Request.Type;
using Refit;

namespace Alexa.NET.Management.Metrics
{
    //https://developer.amazon.com/docs/smapi/metrics-api.html#get-metrics
    public class MetricsRequest
    {
        public MetricsRequest() { }
        public MetricsRequest(DateTime startTime, 
            DateTime endTime, 
            MetricPeriod period,
            string metric,
            SkillStage stage,
            SkillType skillType,
            string intent = null,
            string locale = null)
        {
            StartTime = startTime;
            EndTime = endTime;
            Period = period;
            Metric = metric;
            Stage = stage;
            SkillType = skillType;
            Intent = intent;
            Locale = locale;
        }

        [AliasAs("startTime")]
        public DateTime StartTime { get; set; }

        [AliasAs("endTime")]
        public DateTime EndTime { get; set; }

        [AliasAs("period")]
        public MetricPeriod Period { get; set; }

        [AliasAs("metric")]
        public string Metric { get; set; }

        [AliasAs("stage")]
        public SkillStage Stage { get; set; }

        [AliasAs("skillType")]
        public SkillType SkillType { get; set; }

        [AliasAs("intent")]
        public string Intent { get; set; }

        [AliasAs("locale")]
        public string Locale { get; set; }
    }
}
