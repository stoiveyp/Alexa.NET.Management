using System.Collections.Generic;
using Alexa.NET.Management.Manifest;

namespace Alexa.NET.Management.Api
{
    public class VideoApi:IApi
    {
        public Dictionary<string,VideoLocale> Locales { get; set; }

        public Dictionary<string,VideoRegion> Regions { get; set; }
    }
}