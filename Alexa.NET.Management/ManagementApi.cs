using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
using Newtonsoft.Json;
using Refit;

namespace Alexa.NET.Management
{
    public class ManagementApi
    {
        public const string V1BaseAddress = "https://api.amazonalexa.com/v1";

        public ManagementApi(string token) : this(new Uri(V1BaseAddress, UriKind.Absolute), token)
        {

        }

        public ManagementApi(Func<Task<string>> getToken) : this(new Uri(V1BaseAddress, UriKind.Absolute), getToken)
        {

        }

        public ManagementApi(Uri baseAddress, string token) : this(baseAddress, () => Task.FromResult(token))
        {
        }

        public ManagementApi(Uri baseAddress, Func<Task<string>> getToken)
        {
            var client = new HttpClient(new NoSchemeAuthenticationHeaderClient(getToken)) {BaseAddress = baseAddress};
            Skills = RestService.For<ISkillManagementApi>(
                client,
                new RefitSettings
                {
                    JsonSerializerSettings = new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter>(new[] { new ApiConverter(null) })
                    }
                });

            AccountLinking = new AccountLinkingApi(client);

            InteractionModel = new InteractionModelApi(client);

            Vendors = RestService.For<IVendorApi>(client);
        }

        public ISkillManagementApi Skills { get; set; }

        public IInteractionModelApi InteractionModel { get; set; }

        public IVendorApi Vendors { get; set; }

        public IAccountLinkingApi AccountLinking { get; set; }

    }

    public class NoSchemeAuthenticationHeaderClient : DelegatingHandler
    {
        private readonly Func<Task<string>> GetToken;

        public NoSchemeAuthenticationHeaderClient(Func<Task<string>> getToken):base(new HttpClientHandler())
        {
            GetToken = getToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await GetToken();
            request.Headers.TryAddWithoutValidation("Authorization", token);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
