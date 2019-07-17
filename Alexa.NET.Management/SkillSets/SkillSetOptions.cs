using System;
using System.Collections.Generic;
using System.Linq;

namespace Alexa.NET.Management.SkillSets
{
    public class SkillSetOptions:IComparer<SkillSetLocale>,IComparer<string>
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

        public int Compare(SkillSetLocale x, SkillSetLocale y)
        {
            var xloc = x.Locale;
            var yloc = y.Locale;
            return Compare(xloc, yloc);
        }

        public int Compare(string x, string y)
        {
            var xpos = Array.IndexOf(PreferredLocales,x);
            var ypos = Array.IndexOf(PreferredLocales,y);

            if (xpos == -1 && ypos == -1)
            {
                return string.Compare(x, y, StringComparison.Ordinal);
            }

            if (xpos == -1 && ypos != -1)
            {
                return 1;
            }

            if (xpos != -1 && ypos == -1)
            {
                return -1;
            }

            return xpos < ypos ? -1 : 1;
        }
    }
}