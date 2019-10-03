using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.InSkillProduct;
using Refit;

namespace Alexa.NET.Management
{
    public interface IInSkillProductApi
    {
        Task<Product> Get(string productId, SkillStage stage);

        Task<CreateInSkillProductResponse> Create(Product product);

        Task<ProductSummary> GetSummary(string productId, SkillStage stage);

        Task<Product> Update(string productId, SkillStage stage,Product product);

        Task<bool> Delete(string productId, SkillStage stage);

        Task<ProductListResponse> Get();

        Task<ProductListResponse> Get(int maxResults, GetInSkillProductFilters filters = null);

        Task<ProductListResponse> Get(int maxResults, string nextToken, GetInSkillProductFilters filters = null);

        Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage);

        Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage, int maxResults);

        Task<ProductListResponse> GetSkillProducts(string skillId, SkillStage stage, int maxResults, string nextToken);

        Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage);

        Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage, int maxResults);

        Task<RelatedSkillResponse> GetProductSkills(string productId, SkillStage stage, int maxResults, string nextToken);

        Task<bool> Associate(string productId, string skillId);

        Task<bool> Disassociate(string productId, string skillId);

        Task<bool> ResetDeveloperEntitlement(string productId);
    }
}
