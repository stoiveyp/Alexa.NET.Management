using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
using Alexa.NET.Management.SlotType;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class SlotTypeTests
    {
        [Fact]
        public async Task Create()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                var requestBody = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<CreateSlotRequest>(requestBody);
                Assert.Equal("vendorid",request.VendorId);
                Assert.Equal("testslot",request.SlotType.Name);
                Assert.Equal("desc",request.SlotType.Description);
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/slotTypes", req.RequestUri.PathAndQuery);
            },new CreateSlotResponse{SlotType=new CreateSlotResponseType{Id="ABC123"}}));
            var response = await management.SlotType.Create("vendorid","testslot","desc");
            Assert.Equal("ABC123",response);
        }

        [Fact]
        public async Task Get()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal("/v1/skills/api/custom/interactionModel/slotTypes/ABC123", req.RequestUri.PathAndQuery);
                Assert.Equal(HttpMethod.Get, req.Method);
            }, new GetSlotResponse { SlotType = new SharedSlotType { Name = "testslot",Description = "desc"} }));
            var response = await management.SlotType.Get("ABC123");
            Assert.NotNull(response);
            Assert.Equal("testslot",response.Name);
            Assert.Equal("desc",response.Description);
        }
    }
}
