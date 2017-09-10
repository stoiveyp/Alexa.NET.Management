using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
using Newtonsoft.Json;
using Refit;

namespace Alexa.NET.Management
{
    public class ManagementApi
    {
        private const string V0BaseAddress = "https://api.amazonalexa.com/v0";

        public ManagementApi(string token) : this(new Uri(V0BaseAddress, UriKind.Absolute), token)
        {

        }

        public ManagementApi(Func<Task<string>> getToken) : this(new Uri(V0BaseAddress, UriKind.Absolute), getToken)
        {

        }

        public ManagementApi(Uri baseAddress, string token) : this(baseAddress, () => Task.FromResult(token))
        {
        }

        public ManagementApi(Uri baseAddress, Func<Task<string>> getToken)
        {
            Skills = RestService.For<ISkillManagementApi>(
                baseAddress.ToString(),
                new RefitSettings
                {
                    AuthorizationHeaderValueGetter = getToken,
                    JsonSerializerSettings = new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter>(new[] { new ApiConverter(null) })
                    }
                });

            AccountLinking = RestService.For<IAccountLinkingApi>(
                baseAddress.ToString(),
                new RefitSettings { AuthorizationHeaderValueGetter = getToken }
            );

            InteractionModel = new InteractionModelApi(baseAddress, getToken);
        }

        public ISkillManagementApi Skills { get; set; }

        public IInteractionModelApi InteractionModel { get; set; }

        public IAccountLinkingApi AccountLinking { get; set; }
    }
}
