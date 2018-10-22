using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class PackageTests
    {
        [Fact]
        public void PackageInClientNotNull()
        {
            var client = new ManagementApi("xxx");
            Assert.NotNull(client.Package);
        }
    }
}
