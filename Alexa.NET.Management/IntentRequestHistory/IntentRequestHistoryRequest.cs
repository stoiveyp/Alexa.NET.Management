using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Skills;
using Refit;

namespace Alexa.NET.Management.IntentRequestHistory
{
    internal class ClientIntentRequestHistoryRequest
    {
        public IntentRequestHistoryRequest ClientRequest;

        public ClientIntentRequestHistoryRequest(IntentRequestHistoryRequest clientRequest)
        {
            ClientRequest = clientRequest;
        }

        [AliasAs("nextToken")] public string NextToken => ClientRequest.NextToken;

        [AliasAs("sortField")] public string SortField => ClientRequest.SortField;

        [AliasAs("sortDirection")] public string SortDirection => ClientRequest.SortDirection;

        [AliasAs("maxResults")] public int? MaxResults => ClientRequest.MaxResults;

        [AliasAs("dialogAct.name")] public string DialogActionName => ClientRequest.DialogActionName;

        [AliasAs("locale")] public string Locale => ClientRequest.Locale;

        [AliasAs("intent.confidence.bin")] public string IntentConfidence => ClientRequest.IntentConfidence;

        [AliasAs("stage")] public string Stage => ClientRequest.Stage.HasValue ? ClientRequest.Stage.ToString().ToLower() : null;

        [AliasAs("publicationStatus")] public PublicationStatus? PublicationStatus => ClientRequest.PublicationStatus;

        [AliasAs("utteranceText")] public string UtteranceText => ClientRequest.UtteranceText;

        [AliasAs("intent.name")] public string IntentName => ClientRequest.IntentName;

        [AliasAs("intent.slot.name")] public string IntentSlotName => ClientRequest.IntentSlotName;

        [AliasAs("interactionType")] public InteractionType? InteractionType => ClientRequest.InteractionType;
    }

    public class IntentRequestHistoryRequest
    {

        public string NextToken { get; set; }


        public string SortField { get; set; }


        public string SortDirection { get; set; }


        public int? MaxResults { get; set; }

        public string DialogActionName { get; set; }

        public string Locale { get; set; }

        public string IntentConfidence { get; set; }

        public SkillStage? Stage { get; set; }

        public PublicationStatus? PublicationStatus { get; set; }

        public string UtteranceText { get; set; }

        public string IntentName { get; set; }

        public string IntentSlotName { get; set; }

        public InteractionType? InteractionType { get; set; }
    }
}
