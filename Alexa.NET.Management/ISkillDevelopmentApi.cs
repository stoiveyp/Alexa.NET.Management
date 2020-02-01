using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace Alexa.NET.Management
{
    public interface ISkillDevelopmentApi
    {
        [Get("/SkillDevelopmentApi")]
        Task<HttpResponseMessage> Get();
    }
}
