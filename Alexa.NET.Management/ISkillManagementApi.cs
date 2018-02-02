using System;
using System.Threading.Tasks;
using Alexa.NET.Management.Skills;
using Newtonsoft.Json;
using Refit;

namespace Alexa.NET.Management
{
    public interface ISkillManagementApi
    {
        [Get("/skills/{skillId}/stages/{stage}/manifest")]
        Task<Skill> Get(string skillId, string stage);

        [Post("/skills/{vendorId}")]
        Task<SkillId> Create(string vendorId, [Body]Skill skill);


        [Put("/skills/{skillId}/stages/{stage}/manifest")]
        Task<SkillId> Update(string skillId, string stage, [Body] Skill skill);

        [Get("/skills/{skillId}/status?resource=manifest&resource=interactionModel")]
        Task<SkillStatus> Status(string skillId);

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

    public class SimulationRequest
    {
        [JsonProperty("input")]
        public SimulationRequestInput Input { get; set; }

        [JsonProperty("device")]
        private SimulationRequestDevice Device { get; set; }
    }
}

