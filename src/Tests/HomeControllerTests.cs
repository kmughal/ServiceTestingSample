using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alba;
using Web.Controllers;
using Xunit;

namespace Tests
{
    public class HomeControllerTests
    {

        [Fact]
        public async Task Calling_PostFakeData_WithFakeEmployee_Should_ChangeTheName()
        {
            var hostBuilder = Web.Program.CreateHostBuilder(new string[0]);
            using var system = new SystemUnderTest(hostBuilder);
            var response = await system.Scenario(_ =>
            {
                _.Post.Input(new Employee { Name = "Fake_Name" }).ToUrl("/Home/PostFakeData");
                _.StatusCodeShouldBeOk();

            });

            var data = response.ResponseBody.ReadAsJson<Employee>();
            Assert.Equal("khurram", data.Name);

        }


        [Fact]
        public async Task Calling_GetFakeJson_Should_Return_Fake_Json()
        {
            var hostBuilder = Web.Program.CreateHostBuilder(new string[0]);

            using var system = new SystemUnderTest(hostBuilder);
            var response = await system.Scenario(_ =>
            {
                _.Get.Url("/Home/GetFakeJson");
                _.Get.Url("/Home/GetFakeJson").ContentType("application/json");
                _.StatusCodeShouldBeOk();

            });

            var data = response.ResponseBody.ReadAsJson<List<Employee>>();
            Assert.Equal(24, data.Count);
        }
    }
}
