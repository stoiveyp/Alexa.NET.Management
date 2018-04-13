using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Alexa.NET.Management
{
    public class NoSchemeAuthenticationHeaderClient : DelegatingHandler
    {
        private readonly Func<Task<string>> GetToken;

        public NoSchemeAuthenticationHeaderClient(Func<Task<string>> getToken) : this(getToken, new HttpClientHandler())
        {
            
        }

        public NoSchemeAuthenticationHeaderClient(Func<Task<string>> getToken, HttpMessageHandler handler):base(handler ?? new HttpClientHandler())
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