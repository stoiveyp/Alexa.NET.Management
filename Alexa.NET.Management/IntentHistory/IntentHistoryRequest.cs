using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.NET.Management.IntentHistory
{
    public class IntentHistoryRequest
    {
        [Refit.AliasAs("nextToken")]
        public string NextToken { get; set; }
    }
}
