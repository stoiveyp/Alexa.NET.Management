using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class WithdrawalRequest
    {
        [JsonProperty("reason")]
        public WithdrawalReason Reason { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

