using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alexa.NET.Management.Tests
{
    public static class Utility
    {
        private const string ExamplesPath = "Examples";

        public static Task<HttpResponseMessage> AsTask(this HttpResponseMessage message)
        {
            return Task.FromResult(message);
        }
        public static bool CompareJson(object actual, string expectedFile, params string[] exclude)
        {
            var actualJObject = JObject.FromObject(actual);
            var expected = File.ReadAllText(Path.Combine(ExamplesPath, expectedFile));
            var expectedJObject = JObject.Parse(expected);

            foreach (var item in exclude)
            {
                RemoveFrom(actualJObject, item);
                RemoveFrom(expectedJObject, item);
            }

            var result = JToken.DeepEquals(expectedJObject, actualJObject);

            if (!result)
            {
                OutputTrimEqual(expectedJObject, actualJObject);
            }

            return result;
        }

        private static void OutputTrimEqual(JObject expectedJObject, JObject actualJObject, bool output = true)
        {
            foreach (var prop in actualJObject.Properties().ToArray())
            {
                if (JToken.DeepEquals(actualJObject[prop.Name], expectedJObject[prop.Name]))
                {
                    actualJObject.Remove(prop.Name);
                    expectedJObject.Remove(prop.Name);
                }
            }

            foreach (var prop in actualJObject.Properties().Where(p => p.Value is JObject).Select(p => new{name=p.Name,value=p.Value as JObject}).ToArray())
            {
                OutputTrimEqual(prop.value,expectedJObject[prop.name].Value<JObject>(),false);
            }

            if (output)
            {
                Console.WriteLine(expectedJObject.ToString());
                Console.WriteLine(actualJObject.ToString());
            }
        }

        private static void RemoveFrom(JObject exclude, string item)
        {
            if (exclude.ContainsKey(item))
            {
                exclude.Remove(item);
            }

            foreach (var prop in exclude.Properties().Where(p => p.Value is JObject).Select(p => p.Value)
                .Cast<JObject>())
            {
                RemoveFrom(prop, item);
            }

            foreach (var prop in exclude.Properties().Where(p => p.Value is JArray).Select(p => p.Value).Cast<JArray>().SelectMany(a => a.Children())
                .Where(c => c.Type == JTokenType.Object).Cast<JObject>())
            {
                RemoveFrom(prop, item);
            }
        }

        public static T ExampleFileContent<T>(string expectedFile)
        {
            using (var reader = new JsonTextReader(new StringReader(ExampleFileContent(expectedFile))))
            {
                return new JsonSerializer().Deserialize<T>(reader);
            }
        }

        public static string ExampleFileContent(string expectedFile)
        {
            return File.ReadAllText(Path.Combine(ExamplesPath, expectedFile));
        }
    }

}
