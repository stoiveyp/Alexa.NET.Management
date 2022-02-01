﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Experiments;
using Alexa.NET.Management.Internals;
using Refit;

namespace Alexa.NET.Management
{
    public class ExperimentApi:IExperimentApi
    {
        private IClientExperimentApi Client { get; }

        public ExperimentApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientExperimentApi>(httpClient, ManagementRefitSettings.Create());
        }

        public async Task<Uri> Create(string skillId, Experiment request)
        {
            var response = await Client.Create(skillId, new ExperimentRequest<Experiment>(request));
            return await response.UriOrError(HttpStatusCode.Created);
        }

        public Task<ExperimentResponse<ExperimentDetail>> Get(string skillId, string experimentId)
        {
            return Client.Get(skillId, experimentId);
        }

        public Task<ExperimentListResponse> List(string skillId)
        {
            return Client.List(skillId);
        }

        public Task<ExperimentListResponse> List(string skillId, int maxResults)
        {
            return Client.List(skillId, maxResults);
        }

        public Task<ExperimentListResponse> List(string skillId, int maxResults, string nextToken)
        {
            return Client.List(skillId, maxResults, nextToken);
        }

        public Task<ExperimentResponse<Experiment>> Update(string skillId, string experimentId, ExperimentUpdate request)
        {
            return Client.Update(skillId, experimentId, new ExperimentRequest<ExperimentUpdate>(request));
        }
    }
}