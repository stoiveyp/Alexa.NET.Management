using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Package;
using Newtonsoft.Json;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class SkillPackageApi : ISkillPackageApi
    {
        private IClientSkillPackageApi Client { get; }

        public SkillPackageApi(HttpClient client)
        {
            Client = RestService.For<IClientSkillPackageApi>(client);
        }

        public async Task<PackageUploadMetadata> CreateUpload()
        {
            var response = await Client.CreateUpload();

            string body = string.Empty;

            if (response.Content != null)
            {
                body = await response.Content.ReadAsStringAsync();
            }

            if (response.StatusCode != HttpStatusCode.Created)
            {
                throw new InvalidOperationException(
                    $"Expected Status Code 201. Received {(int)response.StatusCode}. Response Body: {body}");
            }

            return JsonConvert.DeserializeObject<PackageUploadMetadata>(body);
        }
    }
}
