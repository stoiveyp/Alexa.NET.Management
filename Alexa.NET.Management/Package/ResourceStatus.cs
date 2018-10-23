using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.NET.Management.Package
{
    public enum ResourceStatus
    {
        FAILED,
        IN_PROGRESS,
        SUCCEEDED,
        ROLLBACK_IN_PROGRESS,
        ROLLBACK_SUCCEEDED,
        ROLLBACK_FAILED
    }
}
