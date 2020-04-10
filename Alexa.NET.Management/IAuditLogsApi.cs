using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Audit;
using Refit;

namespace Alexa.NET.Management
{
    public interface IAuditLogsApi
    {
        [Post("/developmentAuditLogs/query")]
        Task<QueryResponse> Query([Body]QueryRequest request);
    }
}
