using System;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
using Refit;

namespace Alexa.NET.Management
{
    public class ManagementApi
    {
        public const string V1BaseAddress = "https://api.amazonalexa.com/v1";

        public ManagementApi(string token) : this(new Uri(V1BaseAddress, UriKind.Absolute), token, null)
        {

        }

        public ManagementApi(string token, HttpMessageHandler handler) : this(new Uri(V1BaseAddress, UriKind.Absolute), token, handler)
        {

        }

        public ManagementApi(Func<Task<string>> getToken) : this(new Uri(V1BaseAddress, UriKind.Absolute), getToken, null)
        {

        }

        public ManagementApi(Func<Task<string>> getToken, HttpMessageHandler handler) : this(new Uri(V1BaseAddress, UriKind.Absolute), getToken, handler)
        {

        }

        public ManagementApi(Uri baseAddress, string token) : this(baseAddress, () => Task.FromResult(token), null)
        {
        }

        public ManagementApi(Uri baseAddress, string token, HttpMessageHandler handler) : this(baseAddress, () => Task.FromResult(token), handler)
        {
        }

        public ManagementApi(Uri baseAddress, Func<Task<string>> getToken) : this(baseAddress, getToken, null)
        {
        }

        public ManagementApi(Uri baseAddress, Func<Task<string>> getToken, HttpMessageHandler handler)
        {
            var client = new HttpClient(new NoSchemeAuthenticationHeaderClient(getToken, handler)) { BaseAddress = baseAddress };

            Skills = new SkillManagementApi(client);

            AccountLinking = new AccountLinkingApi(client);

            InteractionModel = new InteractionModelApi(client);

            Vendors = RestService.For<IVendorApi>(client);

            Enablement = new SkillEnablementApi(client);

            IntentRequestHistory = RestService.For<IIntentRequestHistoryApi>(client);

            SkillValidation = new SkillValidationApi(client);

            InSkillProducts = RestService.For<IInSkillProductApi>(client);
        }

        public IIntentRequestHistoryApi IntentRequestHistory { get; set; }

        public ISkillEnablementApi Enablement { get; set; }

        public ISkillManagementApi Skills { get; set; }

        public IInteractionModelApi InteractionModel { get; set; }

        public IVendorApi Vendors { get; set; }

        public IAccountLinkingApi AccountLinking { get; set; }
        public ISkillValidationApi SkillValidation { get; set; }

        public IInSkillProductApi InSkillProducts { get; set; }
    }
}
