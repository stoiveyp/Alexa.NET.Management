using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alexa.NET.Management.SkillSets
{
    public static class SkillSetExtensions
    {
        public static async Task<IEnumerable<SkillSet>> FromVendor(this ManagementApi api, string vendorId, SkillSetOptions options = null)
        {
            var response = await api.Skills.List(vendorId);
            return SkillSet.From(options,response.Skills);
        }
    }
}