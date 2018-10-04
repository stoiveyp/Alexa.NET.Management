using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.InSkillProduct;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class InProductSkillsApi : IInSkillProductApi
    {
        private IClientInSkillProductApi Client { get; }

        public InProductSkillsApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientInSkillProductApi>(httpClient);
        }

        public Task<Product> Get(string productId, SkillStage stage)
        {
            return Client.Get(productId, stage);
        }

        public Task<CreateInSkillProductResponse> Create(Product product)
        {
            return Client.Create(product);
        }

        public Task<ProductSummary> GetSummary(string productId, SkillStage stage)
        {
            return Client.GetSummary(productId, stage);
        }

        public Task<Product> Update(string productId, SkillStage stage, Product product)
        {
            return Client.Update(productId, stage, product);
        }

        public async Task<bool> Delete(string productId, SkillStage stage)
        {
            var response = await Client.Delete(productId, stage);
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public Task<ProductListResponse> Get()
        {
            return Client.GetList();
        }

        public Task<ProductListResponse> Get(int maxResults, GetInSkillProductFilters filters = null)
        {
            return Client.GetList(maxResults, filters?.Stage, filters?.Status, filters?.Type, filters?.IsAssociatedWithSkill);
        }

        public Task<ProductListResponse> Get(int maxResults, string nextToken, GetInSkillProductFilters filters = null)
        {
            return Client.GetList(maxResults, nextToken,filters?.Stage, filters?.Status, filters?.Type, filters?.IsAssociatedWithSkill);
        }

        public Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage)
        {
            return Client.GetSkillProducts(skillId, stage);
        }

        public Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage, int maxResults)
        {
            return Client.GetSkillProducts(skillId, stage, maxResults);
        }

        public Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage, int maxResults, string nextToken)
        {
            return Client.GetSkillProducts(skillId, stage, maxResults,nextToken);
        }

        public Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage)
        {
            return Client.GetProductSkills(productId, stage);
        }

        public Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage, int maxResults)
        {
            return Client.GetProductSkills(productId, stage, maxResults);
        }

        public Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage, int maxResults, string nextToken)
        {
            return Client.GetProductSkills(productId, stage, maxResults, nextToken);
        }

        public async Task<bool> Associate(string productId, string skillId)
        {
            var response = await Client.Associate(productId, skillId);
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> Disassociate(string productId, string skillId)
        {
            var response = await Client.Disassociate(productId, skillId);
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> ResetDeveloperEntitlement(string productId)
        {
            var response = await Client.ResetDeveloperEntitlement(productId);
            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}
