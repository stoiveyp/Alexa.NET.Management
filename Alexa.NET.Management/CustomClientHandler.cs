using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Alexa.NET.Management
{
    internal class CustomClientHandler : HttpClientHandler
    {
        private Func<Task<string>> Handler { get; }

        public CustomClientHandler(Func<Task<string>> tokenHandler)
        {
            Handler = tokenHandler;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = request.Headers.Authorization;
            if (auth == null)
            {
                return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }

            var token = await Handler().ConfigureAwait(false);
            request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}