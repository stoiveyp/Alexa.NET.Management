using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.InSkillProduct;
using Refit;

namespace Alexa.NET.Management
{
    public interface IInSkillProductApi
    {
        [Get("/v1/inSkillProducts/{productId}/stages/{stage}")]
        Task<Product> Get(string productId, SkillStage stage);

        [Post("/v1/inSkillProducts")]
        Task<CreateInSkillProductResponse> Create(Product product);

        [Get("/v1/inSkillProducts/{productId}/stages/{stage}/summary")]
        Task<ProductSummary> GetSummary(string productId, SkillStage stage);

        [Put("/v1/inSkillProducts/{productId}/stages/{stage}")]
        Task<Product> Update(string productId, SkillStage stage, Product product);
    }
}
