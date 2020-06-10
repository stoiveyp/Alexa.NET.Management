using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.NET.Management
{
    public interface IAsrApi
    {
        IAsrAnnotationSetsApi AnnotationSets { get; }

        IAsrEvaluationsApi Evaluations { get; }
    }
}
