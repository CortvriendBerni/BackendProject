using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Formula1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace Formula1.Test
{
    public class FormulaControllerTests : IClassFixture<WebApplicationFactory<Formula1.Startup>>
    {
        public HttpClient Client {get; set;}
        public FormulaControllerTests(WebApplicationFactory<Formula1.Startup> fixture)
        {
            Client = fixture.CreateClient();
        }


        [Fact]
        public async Task Test_ReturnsUnauthorizedResult() {
            // Arrange
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            var client = server.CreateClient();
            var url = "/drivers";
            var expected = HttpStatusCode.Unauthorized;

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal(expected, response.StatusCode);
        }

        [Fact]
        public async Task Test_Get_Brands_Should_Return_Ok()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjRJampQeE5wNmtobW5TVXQtZGU4VCJ9.eyJpc3MiOiJodHRwczovL2Rldi16c3JiMDM4ZS5ldS5hdXRoMC5jb20vIiwic3ViIjoiSUNtbFpvTXg5cWdaODJUb2NuOXNIYVo5TUdIQlBjcTRAY2xpZW50cyIsImF1ZCI6Imh0dHA6Ly9mb3JtdWxhMSIsImlhdCI6MTYxOTg3NzE5MywiZXhwIjoxNjE5OTYzNTkzLCJhenAiOiJJQ21sWm9NeDlxZ1o4MlRvY245c0hhWjlNR0hCUGNxNCIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyJ9.nQvrGusBfCN-b5v-CZGLbps303Ujj8KPQ16xlw2xl-6Qm8IY1w9J0EsrU1AnPC4oKXs3orP0BAmigN37VTefPuBnT3f6BvAALJgNdDLj4xLi1jZaxOKsYi4LKOUERgxwXOCvrYNRPhTlu_wS7MxcGaiW7Mqc0UiUs51yaWjyohWs5hSJaxKL-2nTLBsMUoS1Lih4le89FlmiSjx6QBmqm_qR4kbL_AmeArA38_43ZwJiaVjidiAxSFnTlunpQkOeVYLS_hrRd5D-Od111QLsJ-5lXUlg_sb-JblqeRKJxeqAsc62a_FVPijM_BJADDRYWpNw0-DD9jU4Dcrp6a40aQ");
            var response = await Client.GetAsync("/drivers");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var drivers = JsonConvert.DeserializeObject<List<Driver>>(await response.Content.ReadAsStringAsync());
            Assert.True(drivers.Count > 0);
        }

        [Fact]
        public async Task Test_Add_Circuit_Should_Return_Ok()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjRJampQeE5wNmtobW5TVXQtZGU4VCJ9.eyJpc3MiOiJodHRwczovL2Rldi16c3JiMDM4ZS5ldS5hdXRoMC5jb20vIiwic3ViIjoiSUNtbFpvTXg5cWdaODJUb2NuOXNIYVo5TUdIQlBjcTRAY2xpZW50cyIsImF1ZCI6Imh0dHA6Ly9mb3JtdWxhMSIsImlhdCI6MTYxOTg3NzE5MywiZXhwIjoxNjE5OTYzNTkzLCJhenAiOiJJQ21sWm9NeDlxZ1o4MlRvY245c0hhWjlNR0hCUGNxNCIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyJ9.nQvrGusBfCN-b5v-CZGLbps303Ujj8KPQ16xlw2xl-6Qm8IY1w9J0EsrU1AnPC4oKXs3orP0BAmigN37VTefPuBnT3f6BvAALJgNdDLj4xLi1jZaxOKsYi4LKOUERgxwXOCvrYNRPhTlu_wS7MxcGaiW7Mqc0UiUs51yaWjyohWs5hSJaxKL-2nTLBsMUoS1Lih4le89FlmiSjx6QBmqm_qR4kbL_AmeArA38_43ZwJiaVjidiAxSFnTlunpQkOeVYLS_hrRd5D-Od111QLsJ-5lXUlg_sb-JblqeRKJxeqAsc62a_FVPijM_BJADDRYWpNw0-DD9jU4Dcrp6a40aQ");
            
            var circuit = new Circuit()
            {
                CircuitId = "testObject2", 
                CircuitName = "Circuit Du Test", 
                Country = "Belgium", 
                Url = "https://f1-circuits.nl/test"
            };

            string json = JsonConvert.SerializeObject(circuit);

            var response = await Client.PostAsync("/circuit", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var createdCircuit = JsonConvert.DeserializeObject<Circuit>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(createdCircuit);
            Assert.Equal<string>("Circuit Du Test", createdCircuit.CircuitName);
        }
    }
}
