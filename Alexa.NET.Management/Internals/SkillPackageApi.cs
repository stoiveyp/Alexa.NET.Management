using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class SkillPackageApi:ISkillPackageApi
    {
        private IClientSkillPackageApi Client { get; }

        public SkillPackageApi(HttpClient client)
        {
            Client = RestService.For<IClientSkillPackageApi>(client);
        }
    }
}
