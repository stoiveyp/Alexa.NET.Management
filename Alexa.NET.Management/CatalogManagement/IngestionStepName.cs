using System.Runtime.Serialization;

namespace Alexa.NET.Management.CatalogManagement
{
    public enum IngestionStepName
    {
        [EnumMember(Value = "UPLOAD")]
        Upload,
        [EnumMember(Value = "SCHEMA_VALIDATION")]
        SchemaValidation
    }
}