using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Skills;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientInteractionModelApi
    {
        [Get("/skills/{skillId}/stages/{stage}/interactionModel/locales/{locale}")]
        Task<SkillInteraction> Get(string skillId, string stage, string locale);

        [Head("/skills/{skillId}/stages/{stage}/interactionModel/locales/{locale}")]
        Task<HttpResponseMessage> GetTag(string skillId, string stage, string locale);

        [Post("/skills/{skillId}/stages/{stage}/interactionModel/locales/{locale}")]
        Task Update(string skillId, string stage, string locale,[Body]SkillInteraction interaction);
    }

    public class BuildStatus
    {
        [JsonProperty("status"),JsonConverter(typeof(StringEnumConverter))]
        public BuildStatusState Status { get; set; }
    }

    public enum BuildStatusState
    {
        IN_PROGRESS,
        SUCCESS,
        FAILED
    }
}