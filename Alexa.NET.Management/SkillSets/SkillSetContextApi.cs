namespace Alexa.NET.Management.SkillSets
{
    public class SkillSetContextApi:ISkillSetContextApi
    {
        public SkillSetContextApi(ManagementApi api, SkillSetContext context)
        {
            Simulation = new SkillSetContextSimulationApi(api, context);
        }

        public ISkillSetContextSimulationApi Simulation { get; }
    }
}