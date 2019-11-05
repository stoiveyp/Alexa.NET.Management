using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Metrics;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class MetricsTests
    {
        [Fact]
        public async Task ApiMakeCorrectly()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/amzn1.ask.skill.001/metrics?maxResults=3&nextToken=token&startTime=2018-11-01T10:45:00Z&endTime=2018-11-02T10:45:00Z&period=SINGLE&metric=uniqueCustomers&stage=live&skillType=custom&locale=en-US", System.Web.HttpUtility.UrlDecode(req.RequestUri.PathAndQuery));
            }));

            var startDate = new DateTime(2018, 11, 01, 10, 45, 00);
            var endDate = startDate.AddDays(1);
            var response = await management.Metrics.Get("amzn1.ask.skill.001", 3, "token",
                new MetricsRequest(
                startDate,
                endDate,
                MetricPeriod.Single,
                MetricNames.Custom.UniqueCustomers,
                SkillStage.Live,
                SkillType.Custom
                , null,
                SupportedLocales.EnglishUnitedStates));
        }

        [Fact]
        public void MetricsResponseDeserializesCorrectly()
        {
            var response = Utility.ExampleFileContent<MetricsResponse>("MetricsResponse.json");
            Assert.Equal(MetricNames.Custom.UniqueCustomers, response.Metric);
            Assert.Equal(3, response.Timestamps.Length);
            Assert.True(new double[]{10,20,30}.Zip(response.Values,(a,b) => new KeyValuePair<double,double>(a,b)).All(r => r.Key == r.Value));

            var datetime = new DateTime(2018, 11, 01, 10, 45, 00);
            Assert.True(new[] { datetime,datetime,datetime }.Zip(response.Timestamps, (a, b) => new KeyValuePair<DateTime, DateTime>(a, b)).All(r => r.Key == r.Value));
            Assert.Equal("string", response.NextToken);
        }
    }
}
