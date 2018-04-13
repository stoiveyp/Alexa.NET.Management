using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.NET.Management.Validation
{
    public class SkillValidationResponse
    {
        public string Id { get; set; }
        public ValidationStatus Status { get; set; }
        public ValidationResult Result { get; set; }
    }
}
