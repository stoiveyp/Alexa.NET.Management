using System;
using System.Collections.Generic;
using System.Linq;

namespace Alexa.NET.Management.SkillSets
{
    public class SkillSetOptions
    {
        public SkillSetOptions():this("en-US")
        {
            
        }

        public SkillSetOptions(params string[] localePreference)
        {
            PreferredLocales = localePreference;
        }

        public string[] PreferredLocales { get; set; }

        public T GetKeyByPreferredLocale<T>(Dictionary<string, T> set, Func<Dictionary<string,T>,T> defaultLocale) where T:class
        {
            var preferred = GetByPreferredLocale(set, (d, l) => d.ContainsKey(l) ? d[l] : null);
            return preferred ?? defaultLocale(set);
        }

        public T GetByPreferredLocale<TSet, T>(TSet set, Func<TSet, string, T> getByLocale)
        {
            return PreferredLocales.Select(l => getByLocale(set, l)).FirstOrDefault(r => r != null);
        }
    }
}