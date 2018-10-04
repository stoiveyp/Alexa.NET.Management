using Alexa.NET.Management.Api;
using Alexa.NET.Management.InSkillProduct;

namespace Alexa.NET.Management
{
    public class GetInSkillProductFilters
    {
        public SkillStage? Stage { get; set; }
        public ProductStatus? Status { get; set; }
        public string Type { get; set; }
        public bool? IsAssociatedWithSkill { get; set; }
    }
}