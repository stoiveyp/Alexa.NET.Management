using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Skills;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface ISkillManagementClient
    {
        [Get("/skills/{skillId}/status")]
        Task<SkillStatus> Status(string skillId, [Query]SkillResourceContainer container);

        [Get("/skills/{skillId}/stages/{stage}/manifest")]
        Task<Skill> Get(string skillId, string stage);

        [Post("/skills/{vendorId}")]
        Task<SkillId> Create(string vendorId, [Body]Skill skill);


        [Put("/skills/{skillId}/stages/{stage}/manifest")]
        Task<SkillId> Update(string skillId, string stage, [Body] Skill skill);

        [Post("/skills/{skillId}/submit")]
        Task Submit(string skillId);

        [Post("/skills/{skillId}/withdraw")]
        Task Withdraw(string skillId, [Body]WithdrawalRequest request);

        [Post("/skills/{skillId}/invocations")]
        Task<InvocationResponse> Invoke(string skillId, [Body]InvocationRequest request);

        [Post("/skills/{skillId}/simulations")]
        Task<InvocationResponse> Simulate(string skillId, [Body] SimulationRequest request);


        [Get("/skills/{skillId}/simulations/{simulationId}")]
        Task<InvocationResponse> SimulationResult(string skillId, string simulationId);
    }
}
