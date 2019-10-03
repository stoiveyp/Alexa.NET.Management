using Newtonsoft.Json;

namespace Alexa.NET.Management.CatalogManagement
{
    public class ETagPart
    {
        public ETagPart() { }

        public ETagPart(string eTag, int partNumber)
        {
            ETag = eTag;
            PartNumber = partNumber;
        }

        [JsonProperty("eTag")]
        public string ETag { get; set; }

        [JsonProperty("partNumber")]
        public int PartNumber { get; set; }
    }
}