using Alexa.NET.Management.Manifests;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class ManifestTests
    {
        [Fact]
        public void CustomSkillManifest()
        {
            var manifest = new CustomSkillManifest { 
                Manifest = new SkillManifest{
                    
                }
            };
        }
    }
}
