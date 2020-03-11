using System;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class CatalogValueSupplier : ValueSupplier
    {
        public CatalogValueSupplier() { }
        public CatalogValueSupplier(string catalogId, string version)
        {
            ValueCatalog = new ValueCatalog
            {
                CatalogId = catalogId,
                Version = version
            };
        }

        [JsonProperty("valueCatalog")]
        public ValueCatalog ValueCatalog { get; set; }

        public const string ValueSupplierType = "CatalogValueSupplier";
        public override string Type => ValueSupplierType;
    }
}