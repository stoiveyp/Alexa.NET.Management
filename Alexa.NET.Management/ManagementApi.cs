using System;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
using Alexa.NET.Management.Skills;
using Refit;

namespace Alexa.NET.Management
{
    public class ManagementApi
    {
        public const string BaseAddress = "https://api.amazonalexa.com";

        public ManagementApi(string token) : this(new Uri(BaseAddress, UriKind.Absolute), token, null)
        {

        }

        public ManagementApi(string token, HttpMessageHandler handler) : this(new Uri(BaseAddress, UriKind.Absolute), token, handler)
        {

        }

        public ManagementApi(Func<Task<string>> getToken) : this(new Uri(BaseAddress, UriKind.Absolute), getToken, null)
        {

        }

        public ManagementApi(Func<Task<string>> getToken, HttpMessageHandler handler) : this(new Uri(BaseAddress, UriKind.Absolute), getToken, handler)
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

        public ManagementApi(Uri baseAddress, Func<Task<string>> getToken, HttpMessageHandler handler):this(
            new HttpClient(new NoSchemeAuthenticationHeaderClient(getToken, handler)) { BaseAddress = baseAddress }
        )
        {

        }

        public ManagementApi(HttpClient client)
        {
            Skills = new SkillManagementApi(client);

            AccountLinking = new AccountLinkingApi(client);

            InteractionModel = new InteractionModelApi(client);

            Vendors = RestService.For<IVendorApi>(client,ManagementRefitSettings.Create());

            Enablement = new SkillEnablementApi(client);

            IntentRequestHistory = new IntentRequestHistoryApi(client);

            SkillValidation = new SkillValidationApi(client);

            InSkillProducts = new InProductSkillsApi(client);

            Beta = new SkillBetaApi(client);

            Package = new SkillPackageApi(client);

            UtteranceProfiler = new SkillUtteranceProfilerApi(client);

            Nlu = new NluApiContainer(
                new NluAnnotationSetApi(client),
                new NluEvaluationApi(client));

            CatalogManagement = new SkillCatalogManagementApi(client);

            Metrics = RestService.For<IMetricsApi>(client, ManagementRefitSettings.Create());

            SkillDevelopment = new SkillDevelopmentApi(client);

            SlotType = new SlotTypeApi(client);

            AuditLogs = RestService.For<IAuditLogsApi>(client,ManagementRefitSettings.Create());

            Asr = new AsrApi(client);

            ReferenceCatalogManagement = new ReferenceCatalogManagementApi(client);

            KnowledgeSkill = new KnowledgeSkillApi(client);
        }

        public IReferenceCatalogManagementApi ReferenceCatalogManagement { get; set; }
        public IKnowledgeSkillApi KnowledgeSkill { get; }
        public IAsrApi Asr { get; set; }

        public ISkillDevelopmentApi SkillDevelopment { get; set; }

        public IMetricsApi Metrics { get; set; }
        public ICatalogManagementApi CatalogManagement { get; set; }

        public IIntentRequestHistoryApi IntentRequestHistory { get; set; }

        public ISkillEnablementApi Enablement { get; set; }

        public ISkillManagementApi Skills { get; set; }

        public IInteractionModelApi InteractionModel { get; set; }

        public IVendorApi Vendors { get; set; }

        public IAccountLinkingApi AccountLinking { get; set; }

        public ISkillValidationApi SkillValidation { get; set; }

        public IInSkillProductApi InSkillProducts { get; set; }

        public IBetaTestApi Beta { get; set; }

        public ISkillPackageApi Package { get; set; }

        public IUtteranceProfilerApi UtteranceProfiler { get; set; }

        public NluApiContainer Nlu { get; set; }

        public ISlotTypeApi SlotType { get; set; }

        public IAuditLogsApi AuditLogs { get; set; }
    }
}
