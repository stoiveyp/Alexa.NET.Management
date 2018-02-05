using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alexa.NET.Management
{
    public interface ISkillEnablementApi
    {
        Task<bool> Enable(string skillId);

        Task<bool> CheckEnablement(string skillId);

        Task<bool> Disable(string skillId);
    }
}
