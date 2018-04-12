using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Skills;
using Refit;

namespace Alexa.NET.Management.IntentHistory
{
    public class IntentRequestHistoryRequest
    {
        [AliasAs("nextToken")]
        public string NextToken { get; set; }

        [AliasAs("sortField")]
        public string SortField { get; set; }

        [AliasAs("sortDirection")]
        public string SortDirection { get; set; }

        [AliasAs("maxResults")]
        public int? MaxResults { get; set; }

        [AliasAs("dialogAct.name")]
        public string DialogActionName { get; set; }

        [AliasAs("locale")]
        public string Locale { get; set; }

        [AliasAs("intent.confidence.bin")]
        public string IntentConfidence { get; set; }

        [AliasAs("stage")]
        public SkillStage? Stage { get; set; }

        [AliasAs("publicationStatus")]
        public PublicationStatus? PublicationStatus { get; set; }

        [AliasAs("utteranceText")]
        public string UtteranceText { get; set; }

        [AliasAs("intent.name")]
        public string IntentName { get; set; }

        [AliasAs("intent.slot.name")]
        public string IntentSlotName { get; set; }

        [AliasAs("interactionType")]
        public InteractionType? InteractionType { get; set; }
    }
}
