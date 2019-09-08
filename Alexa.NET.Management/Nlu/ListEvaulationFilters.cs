using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Management.Api;

namespace Alexa.NET.Management.Nlu.Evaluation
{
    public class ListEvaulationFilters
    {
        public string Locale { get; set; }
        public SkillStage? Stage { get; set; }
        public string AnnotationId { get; set; }
        public int? MaxResults { get; set; }
    }
}
