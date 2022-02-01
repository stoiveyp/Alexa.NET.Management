using System;
using System.Threading.Tasks;
using Alexa.NET.Management.Asr.Evaluations;
using Alexa.NET.Management.KnowledgeSkill;

namespace Alexa.NET.Management
{
    public interface IKnowledgeSkillApi
    {
        Task<Uri> ImportData(string skillId, string templateId, string content);

        Task<KnowledgeImportStatusResults> GetImports(string skillId);

        Task<KnowledgeImportStatusResults> GetImports(string skillId, KnowledgeImportDescription status);

        Task<KnowledgeImportStatusResults> GetImports(string skillId, int maxResults);

        Task<KnowledgeImportStatusResults> GetImports(string skillId, KnowledgeImportDescription status, int maxResults);

        Task<KnowledgeImportStatusResults> GetImports(string skillId, string nextToken);

        Task<KnowledgeImportStatusResults> GetImports(string skillId, KnowledgeImportDescription status, string nextToken);

        Task<KnowledgeImportStatusResults> GetImports(string skillId, int maxResults, string nextToken);

        Task<KnowledgeImportStatusResults> GetImports(string skillId, KnowledgeImportDescription status, int maxResults, string nextToken);

        Task<KnowledgeImportStatusResult> GetImport(string skillId, string importId);

        Task<KnowledgeTemplateIdResults> GetTemplateIds(string skillId);

        Task<KnowledgeTemplateIdResults> GetTemplateIds(string skillId, string nextToken);

        Task<KnowledgeTemplateIdResults> GetTemplateIds(string skillId, int maxResults);

        Task<KnowledgeTemplateIdResults> GetTemplateIds(string skillId, string nextToken, int maxResults);
    }
}
