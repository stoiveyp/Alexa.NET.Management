using System.Runtime.Serialization;

namespace Alexa.NET.Management.Audit
{
    public enum SortField
    {
        [EnumMember(Value= "timestamp")]
        Timestamp,
        [EnumMember(Value = "client.id")]
        ClientId,
        [EnumMember(Value = "operation.name")]
        OperationName,
        [EnumMember(Value = "resource.id")]
        ResourceId,
        [EnumMember(Value = "resource.type")]
        ResourceType,
        [EnumMember(Value = "httpResponseCode")]
        HttpResponseCode,
        [EnumMember(Value = "requester.userId")]
        RequesterUserId
    }
}