using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Asr.Evaluations;
using Alexa.NET.Management.KnowledgeSkill;
using Refit;

namespace Alexa.NET.Management.Internals
{
    //https://developer.amazon.com/en-US/docs/alexa/knowledge/knowledge-skill-smapi-operations.html
    public interface IClientKnowledgeSkillApi
    {
        [Post("/v1/skills/{skillId}/knowledge/imports")]
        Task<HttpResponseMessage> ImportData(string skillId, [Body]KnowledgeImportDataRequest knowledgeImport);

        [Get("/v1/skills/{skillId}/knowledge/imports")]
        Task<KnowledgeImportStatusResults> GetImports(string skillId);

        [Get("/v1/skills/{skillId}/knowledge/imports")]
        Task<KnowledgeImportStatusResults> GetImports(string skillId, KnowledgeImportDescription status);

        [Get("/v1/skills/{skillId}/knowledge/imports")]
        Task<KnowledgeImportStatusResults> GetImports(string skillId, int maxResults);

        [Get("/v1/skills/{skillId}/knowledge/imports")]
        Task<KnowledgeImportStatusResults> GetImports(string skillId, KnowledgeImportDescription status, int maxResults);

        [Get("/v1/skills/{skillId}/knowledge/imports")]
        Task<KnowledgeImportStatusResults> GetImports(string skillId, string nextToken);

        [Get("/v1/skills/{skillId}/knowledge/imports")]
        Task<KnowledgeImportStatusResults> GetImports(string skillId, KnowledgeImportDescription status, string nextToken);

        [Get("/v1/skills/{skillId}/knowledge/imports")]
        Task<KnowledgeImportStatusResults> GetImports(string skillId, int maxResults, string nextToken);

        [Get("/v1/skills/{skillId}/knowledge/imports")]
        Task<KnowledgeImportStatusResults> GetImports(string skillId, KnowledgeImportDescription status, int maxResults, string nextToken);

        [Get("/v1/skills/{skillId}/knowledge/imports/{importId}")]
        Task<KnowledgeImportStatusResult> GetImport(string skillId, string importId);

        [Get("/v1/skills/{skillId}/knowledge/templates")]
        Task<KnowledgeTemplateIdResults> GetTemplateIds(string skillId);

        [Get("/v1/skills/{skillId}/knowledge/templates")]
        Task<KnowledgeTemplateIdResults> GetTemplateIds(string skillId, string nextToken);

        [Get("/v1/skills/{skillId}/knowledge/templates")]
        Task<KnowledgeTemplateIdResults> GetTemplateIds(string skillId, int maxResults);

        [Get("/v1/skills/{skillId}/knowledge/templates")]
        Task<KnowledgeTemplateIdResults> GetTemplateIds(string skillId, string nextToken, int maxResults);
    }
}
