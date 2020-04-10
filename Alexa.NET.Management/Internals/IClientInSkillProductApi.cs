using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.InSkillProduct;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientInSkillProductApi
    {
        [Get("/v1/inSkillProducts/{productId}/stages/{stage}")]
        Task<Product> Get(string productId, SkillStage stage);

        [Post("/v1/inSkillProducts")]
        Task<CreateInSkillProductResponse> Create([Body]Product product);

        [Get("/v1/inSkillProducts/{productId}/stages/{stage}/summary")]
        Task<ProductSummary> GetSummary(string productId, SkillStage stage);

        [Put("/v1/inSkillProducts/{productId}/stages/{stage}")]
        Task<Product> Update(string productId, SkillStage stage, [Body]Product product);

        [Delete("/v1/inSkillProducts/{productId}/stages/{stage}")]
        Task<HttpResponseMessage> Delete(string productId, SkillStage stage);

        [Get("/v1/inSkillProducts")]
        Task<ProductListResponse> GetList();

        [Get("/v1/inSkillProducts")]
        Task<ProductListResponse> GetList(int maxResults, SkillStage? stage = null, ProductStatus? status = null, string type = null, bool? isAssociatedWithSkill = null);

        [Get("/v1/inSkillProducts")]
        Task<ProductListResponse> GetList(int maxResults, string nextToken, SkillStage? stage = null, ProductStatus? status = null, string type = null, bool? isAssociatedWithSkill = null);

        [Get("/v1/skills/{skillId}/stages/{stage}/inSkillProducts")]
        Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage);

        [Get("/v1/skills/{skillId}/stages/{stage}/inSkillProducts")]
        Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage, int maxResults);

        [Get("/v1/skills/{skillId}/stages/{stage}/inSkillProducts")]
        Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage, int maxResults, string nexToken);

        [Get("/v1/inSkillProducts/{productId}/stages/{stage}/skills")]
        Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage);

        [Get("/v1/inSkillProducts/{productId}/stages/{stage}/skills")]
        Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage, int maxResults);

        [Get("/v1/inSkillProducts/{productId}/stages/{stage}/skills")]
        Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage, int maxResults, string nextToken);

        [Put("/v1/inSkillProducts/{productId}/skills/{skillId}")]
        Task<HttpResponseMessage> Associate(string productId, string skillId);

        [Delete("/v1/inSkillProducts/{productId}/skills/{skillId}")]
        Task<HttpResponseMessage> Disassociate(string productId, string skillId);

        [Delete("/v1/inSkillProducts/{productId}/stages/development/entitlement")]
        Task<HttpResponseMessage> ResetDeveloperEntitlement(string productId);
    }
}
