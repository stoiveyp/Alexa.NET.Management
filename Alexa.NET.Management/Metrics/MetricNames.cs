using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.NET.Management.Metrics
{
    public static class MetricNames
    {
        public static class Custom
        {
            public const string UniqueCustomers = "uniqueCustomers";
            public const string TotalEnablements = "totalEnablements";
            public const string TotalUtterances = "totalUtterances";
            public const string SuccessfulUtterances = "successfulUtterances";
            public const string FailedUtterances = "failedUtterances";
            public const string TotalSessions = "totalSessions";
            public const string SuccessfulSessions = "successfulSessions";
            public const string IncompleteSessions = "incompleteSessions";
            public const string UserEndedSessions = "userEndedSessions";
            public const string SkillEndedSessions = "skillEndedSessions";
        }

        public static class Household
        {
            public const string UniqueCustomers = "uniqueCustomers";
            public const string TotalEnablements = "totalEnablements";
            public const string TotalUtterances = "totalUtterances";
        }

        public static class FlashBriefing
        {
            public const string UniqueCustomers = "uniqueCustomers";
            public const string TotalEnablements = "totalEnablements";
            public const string TotalSessions = "totalSessions";
        }
    }
}
