using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Beta
{
    public class Tester
    {
        [JsonProperty("emailId")]
        public string Email { get; set; }

        [JsonProperty("associationDate")]
        public DateTime AssociationDate { get; set; }

        [JsonProperty("isReminderAllowed")]
        public bool IsReminderAllowed { get; set; }

        [JsonProperty("invitationStatus")]
        public string InvitationStatus { get; set; }


}
}
