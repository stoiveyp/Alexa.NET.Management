using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.NET.Management.Nlu.Evaluation
{
    public class EvaluationResultRequest
    {
        public EvaluationSortField? SortField { get; set; }

        public TestCaseStatus? Status { get; set; }

        public string ActualIntentName { get; set; }

        public string ExpectedIntentName { get; set; }

        public int? MaxResults { get; set; }
    }
}
