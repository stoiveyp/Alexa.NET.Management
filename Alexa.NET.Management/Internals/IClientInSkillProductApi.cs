using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.InSkillProduct;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientInSkillProductApi
    {
        [Get("/inSkillProducts/{productId}/stages/{stage}")]
        Task<Product> Get(string productId, SkillStage stage);

        [Post("/inSkillProducts")]
        Task<CreateInSkillProductResponse> Create([Body]Product product);

        [Get("/inSkillProducts/{productId}/stages/{stage}/summary")]
        Task<ProductSummary> GetSummary(string productId, SkillStage stage);

        [Put("/inSkillProducts/{productId}/stages/{stage}")]
        Task<Product> Update(string productId, SkillStage stage, [Body]Product product);

        [Delete("/inSkillProducts/{productId}/stages/{stage}")]
        Task<HttpResponseMessage> Delete(string productId, SkillStage stage);

        [Get("/inSkillProducts")]
        Task<ProductListResponse> GetList();

        [Get("/inSkillProducts")]
        Task<ProductListResponse> GetList(int maxResults, SkillStage? stage = null, ProductStatus? status = null, string type = null, bool? isAssociatedWithSkill = null);

        [Get("/inSkillProducts")]
        Task<ProductListResponse> GetList(int maxResults, string nextToken, SkillStage? stage = null, ProductStatus? status = null, string type = null, bool? isAssociatedWithSkill = null);

        [Get("/skills/{skillId}/stages/{stage}/inSkillProducts")]
        Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage);

        [Get("/skills/{skillId}/stages/{stage}/inSkillProducts")]
        Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage, int maxResults);

        [Get("/skills/{skillId}/stages/{stage}/inSkillProducts")]
        Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage, int maxResults, string nexToken);

        [Get("/inSkillProducts/{productId}/stages/{stage}/skills")]
        Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage);

        [Get("/inSkillProducts/{productId}/stages/{stage}/skills")]
        Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage, int maxResults);

        [Get("/inSkillProducts/{productId}/stages/{stage}/skills")]
        Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage, int maxResults, string nextToken);

        [Put("/inSkillProducts/{productId}/skills/{skillId}")]
        Task<HttpResponseMessage> Associate(string productId, string skillId);

        [Delete("/inSkillProducts/{productId}/skills/{skillId}")]
        Task<HttpResponseMessage> Disassociate(string productId, string skillId);

        [Delete("/inSkillProducts/{productId}/stages/development/entitlement")]
        Task<HttpResponseMessage> ResetDeveloperEntitlement(string productId);
    }
}
