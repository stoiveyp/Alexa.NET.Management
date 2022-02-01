using System;
using System.Threading.Tasks;
using Alexa.NET.Management.Experiments;
using Refit;

namespace Alexa.NET.Management
{
    public interface IExperimentApi
    {
        Task<Uri> Create(string skillId, [Body]CreateExperimentRequest request);
        Task<ExperimentDetailResponse> Get(string skillId, string experimentId);
    }
}
