namespace Alexa.NET.Management.Internals
{
    public class SkillResourceContainer
    {
        public string[] Resources { get; }

        public SkillResourceContainer(string[] resources)
        {
            this.Resources = resources;
        }
    }
}