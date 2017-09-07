using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Manifests;
using Refit;

namespace Alexa.NET.Management
{
    public class ManagementApi
    {
        private const string V0BaseAddress = "https://api.amazonalexa.com/v0";

        public ManagementApi(string token) : this(new Uri(V0BaseAddress,UriKind.Absolute), token)
        {

        }

        public ManagementApi(Func<Task<string>> getToken) : this(new Uri(V0BaseAddress,UriKind.Absolute), getToken)
        {

        }

        public ManagementApi(Uri baseAddress, string token) : this(baseAddress, () => Task.FromResult(token))
        {
        }

        public ManagementApi(Uri baseAddress, Func<Task<string>> getToken)
        {
            Skills = RestService.For<ISkillManagementApi>(new HttpClient(new CustomClientHandler(getToken)) { BaseAddress = baseAddress });
        }

        public ISkillManagementApi Skills {
            get;
            set;
        }
    }
}
