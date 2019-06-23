namespace Alexa.NET.Management.SkillSets
{
    public class SkillSetLocale
    {
        public SkillSetStage Stage { get; }
        public string Locale { get; }

        public string SkillID => Stage.ID;
        public SkillSetLocale(ManagementApi api, SkillSetStage stage, string locale)
        {
            Stage = stage;
            Locale = locale;
            Api = new SkillSetLocaleApi(this, api);
        }

        public ISkillSetLocaleApi Api { get; }
    }
}