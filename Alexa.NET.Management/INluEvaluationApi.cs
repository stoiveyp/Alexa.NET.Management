using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.NluEvaluation;

namespace Alexa.NET.Management
{
    public interface INluEvaluationApi
    {
        Task<CreateAnnotationSetResponse> Create(string skillId, string locale, string name);

        Task<ListResponse> List(string skillId, string locale = null, int? maxResults = null);

        Task<ListResponse> List(string skillId, string nextToken, string locale = null, int? maxResults = null);

        Task<AnnotationSet> Get(string skillId, string annotationId);

        Task Update(string skillId, string annotationId, AnnotationSet set);

        Task Rename(string skillId, string annotationId, string name);

        Task<AnnotationSetProperties> GetProperties(string skillId, string annotationId);
    }
}
