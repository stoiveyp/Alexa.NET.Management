using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.SlotType;

namespace Alexa.NET.Management
{
    public interface ISlotTypeApi
    {
        Task<string> Create(string vendorId, string slotName, string description = null);
        Task<SharedSlotType> Get(string abc123);
    }
}
