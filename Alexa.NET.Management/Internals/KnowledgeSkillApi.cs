using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Asr.Evaluations;
using Alexa.NET.Management.KnowledgeSkill;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class KnowledgeSkillApi:IKnowledgeSkillApi
    {
        private IClientKnowledgeSkillApi Client { get; }

        public KnowledgeSkillApi(HttpClient httpClient)
        { 
            Client = RestService.For<IClientKnowledgeSkillApi>(httpClient, ManagementRefitSettings.Create());
        }

        public async Task<Uri> ImportData(string skillId, string templateId, string content)
        {
            var response = await Client.ImportData(skillId, new KnowledgeImportDataRequest
            {
                ContentType = "text/csv",
                Template = new KnowledgeTemplateId{Id = templateId},
                ImportContent = content
            });
            return await response.UriOrError(HttpStatusCode.Accepted);
        }

        public Task<KnowledgeImportStatusResults> GetImports(string skillId)
        {
            throw new NotImplementedException();
        }

        public Task<KnowledgeImportStatusResults> GetImports(string skillId, KnowledgeImportDescription status)
        {
            return Client.GetImports(skillId, status);
        }

        public Task<KnowledgeImportStatusResults> GetImports(string skillId, int maxResults)
        {
            return Client.GetImports(skillId, maxResults);
        }

        public Task<KnowledgeImportStatusResults> GetImports(string skillId, KnowledgeImportDescription status, int maxResults)
        {
            return Client.GetImports(skillId, status, maxResults);
        }

        public Task<KnowledgeImportStatusResults> GetImports(string skillId, string nextToken)
        {
            return Client.GetImports(skillId, nextToken);
        }

        public Task<KnowledgeImportStatusResults> GetImports(string skillId, KnowledgeImportDescription status, string nextToken)
        {
            return Client.GetImports(skillId, status, nextToken);
        }

        public Task<KnowledgeImportStatusResults> GetImports(string skillId, int maxResults, string nextToken)
        {
            return Client.GetImports(skillId, maxResults, nextToken);
        }

        public Task<KnowledgeImportStatusResults> GetImports(string skillId, KnowledgeImportDescription status, int maxResults, string nextToken)
        {
            return Client.GetImports(skillId,status, maxResults, nextToken);
        }

        public Task<KnowledgeImportStatusResult> GetImport(string skillId, string importId)
        {
            return Client.GetImport(skillId, importId);
        }

        public Task<KnowledgeTemplateIdResults> GetTemplateIds(string skillId)
        {
            return Client.GetTemplateIds(skillId);
        }

        public Task<KnowledgeTemplateIdResults> GetTemplateIds(string skillId, string nextToken)
        {
            return Client.GetTemplateIds(skillId, nextToken);
        }

        public Task<KnowledgeTemplateIdResults> GetTemplateIds(string skillId, int maxResults)
        {
            return Client.GetTemplateIds(skillId, maxResults);
        }

        public Task<KnowledgeTemplateIdResults> GetTemplateIds(string skillId, string nextToken, int maxResults)
        {
            return Client.GetTemplateIds(skillId, nextToken, maxResults);
        }
    }
}
