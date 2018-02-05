using System;
using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
using Alexa.NET.Management.Skills;
using Refit;

namespace Alexa.NET.Management
{
    public interface ISkillManagementApi
    {
        Task<SkillStatus> Status(string skillId, params string[] resource);
        Task<Skill> Get(string skillId, string stage);
        Task<SkillId> Create(string vendorId, [Body]Skill skill);
        Task<SkillId> Update(string skillId, string stage, [Body] Skill skill);
        Task Submit(string skillId);
        Task Withdraw(string skillId, [Body]WithdrawalRequest request);
        Task<InvocationResponse> Invoke(string skillId, [Body]InvocationRequest request);
        Task<InvocationResponse> Simulate(string skillId, [Body] SimulationRequest request);
        Task<InvocationResponse> SimulationResult(string skillId, string simulationId);
        Task<SkillListResponse> List(string vendorId);
        Task<SkillListResponse> List(string vendorId, params string[] container);
        Task<SkillListResponse> List(string vendorId, int maxResults);
        Task<SkillListResponse> List(string vendorId, int maxResults, string nextToken);
    }
}

