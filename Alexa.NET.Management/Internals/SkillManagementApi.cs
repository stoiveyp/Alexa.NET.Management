using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Skills;
using Newtonsoft.Json;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class SkillManagementApi : ISkillManagementApi
    {
        private ISkillManagementClient Inner { get; }

        public SkillManagementApi(HttpClient client)
        {
            Inner = RestService.For<ISkillManagementClient>(
                client,
                new RefitSettings
                {
                    JsonSerializerSettings = new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter>(new[] { new ApiConverter(null) })
                    }
                });
        }

        public Task<Skill> Get(string skillId, string stage)
        {
            return Inner.Get(skillId, stage);
        }

        public Task<SkillId> Create(string vendorId, Skill skill)
        {
            return Inner.Create(vendorId, skill);
        }

        public Task<SkillId> Update(string skillId, string stage, Skill skill)
        {
            return Inner.Update(skillId, stage, skill);
        }

        public Task<SkillStatus> Status(string skillId, params string[] resources)
        {
            return Inner.Status(skillId, new SkillResourceContainer(resources));
        }

        public Task Submit(string skillId)
        {
            return Inner.Submit(skillId);
        }

        public Task Withdraw(string skillId, WithdrawalRequest request)
        {
            return Inner.Withdraw(skillId, request);
        }

        public Task<InvocationResponse> Invoke(string skillId, InvocationRequest request)
        {
            return Inner.Invoke(skillId, request);
        }

        public Task<InvocationResponse> Simulate(string skillId, SimulationRequest request)
        {
            return Inner.Simulate(skillId, request);
        }

        public Task<InvocationResponse> SimulationResult(string skillId, string simulationId)
        {
            return Inner.SimulationResult(skillId, simulationId);
        }
    }
}
