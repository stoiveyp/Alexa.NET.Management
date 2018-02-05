namespace Alexa.NET.Management.Internals
{
    public class SkillIdContainer
    {
        public string[] SkillId { get; }

        public SkillIdContainer(string[] skills)
        {
            SkillId = skills;
        }
    }
}