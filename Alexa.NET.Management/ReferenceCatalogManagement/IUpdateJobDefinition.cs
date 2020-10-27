using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    [JsonConverter(typeof(UpdateJobConverter))]
    public interface IUpdateJobDefinition
    {
        string Type { get; }
    }
}