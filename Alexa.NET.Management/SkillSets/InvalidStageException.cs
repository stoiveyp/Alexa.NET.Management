using System;

namespace Alexa.NET.Management.SkillSets
{
    public class InvalidStageException : Exception
    {
        public InvalidStageException(string message):base(message)
        {
            
        }
    }
}