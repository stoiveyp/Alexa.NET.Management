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
    }
}
