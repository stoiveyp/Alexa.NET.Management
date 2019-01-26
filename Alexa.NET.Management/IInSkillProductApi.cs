using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.InSkillProduct;
using Refit;

namespace Alexa.NET.Management
{
    public interface IInSkillProductApi
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
        Task<bool> Delete(string productId, SkillStage stage);

        [Get("inSkillProducts")]
        Task<ProductListResponse> Get();

        [Get("inSkillProducts")]
        Task<ProductListResponse> Get(int maxResults, GetInSkillProductFilters filters = null);

        [Get("inSkillProducts")]
        Task<ProductListResponse> Get(int maxResults, string nextToken, GetInSkillProductFilters filters = null);

        [Get("skills/{skillId}/stages/{stage}/inSkillProducts")]
        Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage);

        [Get("skills/{skillId}/stages/{stage}/inSkillProducts")]
        Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage, int maxResults);

        [Get("skills/{skillId}/stages/{stage}/inSkillProducts")]
        Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage, int maxResults, string nextToken);

        [Get("inSkillProducts/{productId}/stages/{stage}/skills")]
        Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage);

        [Get("inSkillProducts/{productId}/stages/{stage}/skills")]
        Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage, int maxResults);

        [Get("inSkillProducts/{productId}/stages/{stage}/skills")]
        Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage, int maxResults, string nextToken);

        [Get("inSkillProducts/{productId}/skills/{skillId}")]
        Task<bool> Associate(string productId, string skillId);

        [Put("inSkillProducts/{productId}/skills/{skillId}")]
        Task<bool> Disassociate(string productId, string skillId);

        [Delete("inSkillProducts/{productId}/stages/development/entitlement")]
        Task<bool> ResetDeveloperEntitlement(string productId);
    }
}
