using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class SkillEnablementApi:ISkillEnablementApi
    {
        private IClientSkillEnablementApi Client { get; }

        public SkillEnablementApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientSkillEnablementApi>(httpClient, ManagementRefitSettings.Create());
        }

        public async Task<bool> Enable(string skillId)
        {
            var response = await Client.Enable(skillId, SkillStage.Development);
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> CheckEnablement(string skillId)
        {
            var response = await Client.Enable(skillId, SkillStage.Development);
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> Disable(string skillId)
        {
            var response = await Client.Disable(skillId, SkillStage.Development);
            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}
