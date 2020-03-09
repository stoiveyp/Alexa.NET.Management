using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Management.InteractionModel;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class InlineValueSupplier:ValueSupplier
    {
        public InlineValueSupplier() { }

        public InlineValueSupplier(params SlotTypeValue[] values)
        {
            Values = values;
        }

        [JsonProperty("values")]
        public SlotTypeValue[] Values { get; set; }

        public const string ValueSupplierType = "InlineValueSupplier";
        public override string Type => ValueSupplierType;
    }
}
