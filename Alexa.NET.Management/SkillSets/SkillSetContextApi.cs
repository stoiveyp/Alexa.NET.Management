namespace Alexa.NET.Management.SkillSets
{
    public class SkillSetContextApi : ISkillSetApi
    {
        private readonly ManagementApi _managementApi;

        public SkillSetContextApi(ManagementApi api)
        {
            _managementApi = api;
        }
    }
}