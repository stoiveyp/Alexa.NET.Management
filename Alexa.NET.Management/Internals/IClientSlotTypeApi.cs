using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.SlotType;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSlotTypeApi
    {
        [Post("/skills/api/custom/interactionModel/slotTypes")]
        Task<CreateSlotResponse> Create([Body]CreateSlotRequest request);

        [Get("/skills/api/custom/interactionModel/slotTypes/{slotId}")]
        Task<GetSlotResponse> Get(string slotId);
    }
}
