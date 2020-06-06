using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class AsrApi:IAsrApi
    {
        public AsrApi(HttpClient client)
        {
            AnnotationSets = new AsrAnnotationSetsApi(client);
            Evaluations = new AsrEvaluationsApi(client);
        }
        public IAsrAnnotationSetsApi AnnotationSets { get; }
        public IAsrEvaluationsApi Evaluations { get; }
    }
}
