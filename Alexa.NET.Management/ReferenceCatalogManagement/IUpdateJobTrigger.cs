using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    [JsonConverter(typeof(UpdateJobTriggerConverter))]
    public interface IUpdateJobTrigger
    {
        public string Type { get; }
    }
}