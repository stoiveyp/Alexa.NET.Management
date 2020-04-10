using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.SlotType;
using Refit;
using Version = Alexa.NET.Management.SlotType.Version;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSlotTypeApi
    {
        [Post("/v1/skills/api/custom/interactionModel/slotTypes")]
        Task<CreateSlotResponse> Create([Body]CreateSlotRequest request);

        [Get("/v1/skills/api/custom/interactionModel/slotTypes/{slotId}")]
        Task<GetSlotResponse> Get(string slotId);

        [Post("/v1/skills/api/custom/interactionModel/slotTypes/{slotId}/update")]
        Task<HttpResponseMessage> Update(string slotId, [Body]UpdateRequest request);

        [Get("/v1/skills/api/custom/interactionModel/slotTypes?vendorId={vendorId}")]
        Task<ListSlotResponse> List(string vendorId, SortDirection sortDirection);

        [Get("/v1/skills/api/custom/interactionModel/slotTypes?vendorId={vendorId}")]
        Task<ListSlotResponse> List(string vendorId, int maxResults, SortDirection sortDirection);

        [Get("/v1/skills/api/custom/interactionModel/slotTypes?vendorId={vendorId}")]
        Task<ListSlotResponse> List(string vendorId, string nextToken);

        [Get("/v1/skills/api/custom/interactionModel/slotTypes/{slotId}/versions")]
        Task<ListSlotVersionsResponse> ListVersions(string slotId, SortDirection sortDirection);

        [Get("/v1/skills/api/custom/interactionModel/slotTypes/{slotId}/versions")]
        Task<ListSlotVersionsResponse> ListVersions(string slotId, int maxResults, SortDirection sortDirection);

        [Get("/v1/skills/api/custom/interactionModel/slotTypes/{slotId}/versions")]
        Task<ListSlotVersionsResponse> ListVersions(string slotId, string nextToken);

        [Delete("/v1/skills/api/custom/interactionModel/slotTypes/{slotId}")]
        Task<HttpResponseMessage> Delete(string slotId);

        [Post("/v1/skills/api/custom/interactionModel/slotTypes/{slotId}/versions")]
        Task<HttpResponseMessage> CreateVersion(string slotId, [Body]Version definition);

        [Get("/v1/skills/api/custom/interactionModel/slotTypes/{slotId}/versions/{versionId}")]
        Task<CreatedVersion> GetVersion(string slotId, string versionId);

        [Get("/v1/skills/api/custom/interactionModel/slotTypes/{slotId}/updateRequest/{updateRequestId}")]
        Task<SlotBuildStatus> BuildStatus(string slotId, string updateRequestId);

        [Post("/v1/skills/api/custom/interactionModel/slotTypes/{slotId}/versions/{version}/update")]
        Task<HttpResponseMessage> UpdateVersion(string slotId, string version, [Body]UpdateRequest request);

        [Delete("/v1/skills/api/custom/interactionModel/slotTypes/{slotId}/versions/{versionId}")]
        Task<HttpResponseMessage> DeleteVersion(string slotId, string versionId);
    }
}
