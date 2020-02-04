using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
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
            Client = RestService.For<IClientSkillPackageApi>(client,ManagementRefitSettings.Create());
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

        public Task<Uri> CreatePackage(string vendorId, string location)
        {
            if (string.IsNullOrWhiteSpace(vendorId))
            {
                throw new ArgumentNullException(nameof(vendorId));
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentNullException(nameof(location));
            }

            return CreatePackage(new CreatePackageRequest {VendorId = vendorId, Location = location});
        }

        public async Task<Uri> CreatePackage(CreatePackageRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var message = await Client.CreatePackage(request);
            return await message.UriOrError(HttpStatusCode.Accepted);
        }

        public async Task<Uri> CreateSkillPackage(string skillId, string location)
        {
            if (string.IsNullOrWhiteSpace(skillId))
            {
                throw new ArgumentNullException(nameof(skillId));
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentNullException(nameof(location));
            }

            var message = await Client.CreateSkillPackage(skillId, new CreateSkillPackageRequest {Location = location});
            return await message.UriOrError(HttpStatusCode.Accepted);
        }

        public Task<ImportStatusResponse> SkillPackageStatus(string importId)
        {
            if (string.IsNullOrWhiteSpace(importId))
            {
                throw new ArgumentNullException(nameof(importId));
            }

            return Client.SkillPackageStatus(importId);
        }

        public async Task<Uri> CreateExportRequest(string skillId, SkillStage stage)
        {
            if (string.IsNullOrWhiteSpace(skillId))
            {
                throw new ArgumentNullException(nameof(skillId));
            }

            var message = await Client.CreateExportRequest(skillId, stage);
            return await message.UriOrError(HttpStatusCode.Accepted);
        }

        public Task<ExportStatusResponse> ExportStatus(string exportId)
        {
            if (string.IsNullOrWhiteSpace(exportId))
            {
                throw new ArgumentNullException(nameof(exportId));
            }

            return Client.ExportStatus(exportId);
        }
    }
}
