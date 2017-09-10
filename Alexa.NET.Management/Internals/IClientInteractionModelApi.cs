using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;

namespace Alexa.NET.Management.Internals
{
    [Headers("Authorization: Bearer")]
    public interface IClientInteractionModelApi
    {
        [Get("skills/{skillId}/interactionModel/locales/{locale}")]
        Task<SkillInteraction> Get(string skillId, string locale);

        [Head("skills/{skillId}/interactionModel/locales/{locale}")]
        Task<HttpResponseMessage> GetTag(string skillId, string locale);

        [Post("skills/{skillId}/interactionModel/locales/{locale}")]
        Task Update(string skillId, string locale,[Body]SkillInteraction interaction);

        [Get("skills/{skillId}/interactionModel/locales/{locale}/status")]
        Task<BuildStatus> Status(string skillId, string locale);
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