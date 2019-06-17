using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Management.Api;

namespace Alexa.NET.Management.SkillSets
{
    public interface ISkillSetSummary
    {
        string ID { get; }
        string Name { get; }

        SkillStage? Stage { get; }
    }
}
