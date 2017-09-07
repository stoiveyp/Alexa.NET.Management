using System;
using System.Threading.Tasks;

namespace Alexa.NET.Management
{
    public class ManagementApi:IManagementApi
    {
        public IManagementApi Client { get; }
        public Func<Task<string>> TokenHandler { get; }

        public ManagementApi(Uri baseAddress, string token):this(baseAddress,() => Task.FromResult(token))
        {
        }

        public ManagementApi(Uri baseAddress, Func<Task<string>> getToken)
        {
            TokenHandler = getToken;
            Client = Refit.RestService.For<IManagementApi>(baseAddress.ToString());
        }
    }
}
