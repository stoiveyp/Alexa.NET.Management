using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.NluEvaluation;

namespace Alexa.NET.Management
{
    public interface INluEvaluationApi
    {
        Task<CreateAnnotationSetResponse> CreateAnnotationSet(string skillId, string locale, string name);

        Task<AnnotationSetsResponse> AnnotationSets(string skillId, string locale = null, int? maxResults = null);

        Task<AnnotationSetsResponse> AnnotationSets(string skillId, string nextToken, string locale = null, int? maxResults = null);

        Task<AnnotationSet> GetAnnotationSet(string skillId, string annotationId);
        Task UpdateAnnotationSet(string skillId, string annotationId, AnnotationSet set);
    }
}
