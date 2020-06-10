using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Management.Api;
using Refit;

namespace Alexa.NET.Management.Asr.Evaluations
{
    public class EvaluationListRequest
    {
        [AliasAs("annotationSetId")]
        public string AnnotationSetId { get; set; }

        [AliasAs("locale")]
        public string Locale { get; set; }

        [AliasAs("maxResults")]
        public int MaxResults { get; set; }

        [AliasAs("stage")]
        public SkillStage? Stage { get; set; }

        [AliasAs("nextToken")]
        public string NextToken { get; set; }
    }
}
