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
        public async Task Test_Get_Drivers_Should_Return_Ok()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjRJampQeE5wNmtobW5TVXQtZGU4VCJ9.eyJpc3MiOiJodHRwczovL2Rldi16c3JiMDM4ZS5ldS5hdXRoMC5jb20vIiwic3ViIjoiSUNtbFpvTXg5cWdaODJUb2NuOXNIYVo5TUdIQlBjcTRAY2xpZW50cyIsImF1ZCI6Imh0dHA6Ly9mb3JtdWxhMSIsImlhdCI6MTYxOTk2NDAzOCwiZXhwIjoxNjIwMDUwNDM4LCJhenAiOiJJQ21sWm9NeDlxZ1o4MlRvY245c0hhWjlNR0hCUGNxNCIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyJ9.AXAjGIfEf3nMjRgb7qgxyDiVuHp0wDkwn1DnbdB70A49h2AHPYIlX61Qzs_Oiyh4KvEobLPltyUzHmlTSPYE2VeJ2dd9UkCwNhTnn3sDSciDMsiw7VVOsgwXQYC5gG6WRmUIHnySh0pw55V6MXxWPDUzW1_dGm1yG74KpiLCe8HXAwxj_8zBQlrKEzuHlOsWHZGPcNqNNY1yAFMOFcCmtsr8RxnJcIdRCH9UHStO34AZveDqw-aMje_wLS4uFah_mG2mAvLYhxaTFLE5hkrRTTz4sOkGDiZruwTNWbrV7ODUXnD5TcKkPnvsfXhTcPoLara2_H98b51Vi7JQZZCc1w");
            var response = await Client.GetAsync("/drivers");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var drivers = JsonConvert.DeserializeObject<List<Driver>>(await response.Content.ReadAsStringAsync());
             // Er moeten altijd 20 drivers op de grid zijn
            Assert.True(drivers.Count == 20);
        }

        [Fact]
        public async Task Test_Get_Teams_Should_Return_Ok()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjRJampQeE5wNmtobW5TVXQtZGU4VCJ9.eyJpc3MiOiJodHRwczovL2Rldi16c3JiMDM4ZS5ldS5hdXRoMC5jb20vIiwic3ViIjoiSUNtbFpvTXg5cWdaODJUb2NuOXNIYVo5TUdIQlBjcTRAY2xpZW50cyIsImF1ZCI6Imh0dHA6Ly9mb3JtdWxhMSIsImlhdCI6MTYxOTk2NDAzOCwiZXhwIjoxNjIwMDUwNDM4LCJhenAiOiJJQ21sWm9NeDlxZ1o4MlRvY245c0hhWjlNR0hCUGNxNCIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyJ9.AXAjGIfEf3nMjRgb7qgxyDiVuHp0wDkwn1DnbdB70A49h2AHPYIlX61Qzs_Oiyh4KvEobLPltyUzHmlTSPYE2VeJ2dd9UkCwNhTnn3sDSciDMsiw7VVOsgwXQYC5gG6WRmUIHnySh0pw55V6MXxWPDUzW1_dGm1yG74KpiLCe8HXAwxj_8zBQlrKEzuHlOsWHZGPcNqNNY1yAFMOFcCmtsr8RxnJcIdRCH9UHStO34AZveDqw-aMje_wLS4uFah_mG2mAvLYhxaTFLE5hkrRTTz4sOkGDiZruwTNWbrV7ODUXnD5TcKkPnvsfXhTcPoLara2_H98b51Vi7JQZZCc1w");
            var response = await Client.GetAsync("/teams");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var teams = JsonConvert.DeserializeObject<List<Team>>(await response.Content.ReadAsStringAsync());
            Assert.True(teams.Count > 0);
        }

        [Fact]
        public async Task Test_Get_Ranking_Should_Return_Ok()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjRJampQeE5wNmtobW5TVXQtZGU4VCJ9.eyJpc3MiOiJodHRwczovL2Rldi16c3JiMDM4ZS5ldS5hdXRoMC5jb20vIiwic3ViIjoiSUNtbFpvTXg5cWdaODJUb2NuOXNIYVo5TUdIQlBjcTRAY2xpZW50cyIsImF1ZCI6Imh0dHA6Ly9mb3JtdWxhMSIsImlhdCI6MTYxOTk2NDAzOCwiZXhwIjoxNjIwMDUwNDM4LCJhenAiOiJJQ21sWm9NeDlxZ1o4MlRvY245c0hhWjlNR0hCUGNxNCIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyJ9.AXAjGIfEf3nMjRgb7qgxyDiVuHp0wDkwn1DnbdB70A49h2AHPYIlX61Qzs_Oiyh4KvEobLPltyUzHmlTSPYE2VeJ2dd9UkCwNhTnn3sDSciDMsiw7VVOsgwXQYC5gG6WRmUIHnySh0pw55V6MXxWPDUzW1_dGm1yG74KpiLCe8HXAwxj_8zBQlrKEzuHlOsWHZGPcNqNNY1yAFMOFcCmtsr8RxnJcIdRCH9UHStO34AZveDqw-aMje_wLS4uFah_mG2mAvLYhxaTFLE5hkrRTTz4sOkGDiZruwTNWbrV7ODUXnD5TcKkPnvsfXhTcPoLara2_H98b51Vi7JQZZCc1w");
            var response = await Client.GetAsync("/ranking");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var ranking = JsonConvert.DeserializeObject<List<Ranking>>(await response.Content.ReadAsStringAsync());
            // Een ranking bevat alle drivers en dus ook 20 drivers
            Assert.True(ranking.Count == 20);
        }

        [Fact]
        public async Task Test_Get_Circuits_Should_Return_Ok()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjRJampQeE5wNmtobW5TVXQtZGU4VCJ9.eyJpc3MiOiJodHRwczovL2Rldi16c3JiMDM4ZS5ldS5hdXRoMC5jb20vIiwic3ViIjoiSUNtbFpvTXg5cWdaODJUb2NuOXNIYVo5TUdIQlBjcTRAY2xpZW50cyIsImF1ZCI6Imh0dHA6Ly9mb3JtdWxhMSIsImlhdCI6MTYxOTk2NDAzOCwiZXhwIjoxNjIwMDUwNDM4LCJhenAiOiJJQ21sWm9NeDlxZ1o4MlRvY245c0hhWjlNR0hCUGNxNCIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyJ9.AXAjGIfEf3nMjRgb7qgxyDiVuHp0wDkwn1DnbdB70A49h2AHPYIlX61Qzs_Oiyh4KvEobLPltyUzHmlTSPYE2VeJ2dd9UkCwNhTnn3sDSciDMsiw7VVOsgwXQYC5gG6WRmUIHnySh0pw55V6MXxWPDUzW1_dGm1yG74KpiLCe8HXAwxj_8zBQlrKEzuHlOsWHZGPcNqNNY1yAFMOFcCmtsr8RxnJcIdRCH9UHStO34AZveDqw-aMje_wLS4uFah_mG2mAvLYhxaTFLE5hkrRTTz4sOkGDiZruwTNWbrV7ODUXnD5TcKkPnvsfXhTcPoLara2_H98b51Vi7JQZZCc1w");
            var response = await Client.GetAsync("/circuits");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var circuits = JsonConvert.DeserializeObject<List<Circuit>>(await response.Content.ReadAsStringAsync());
            Assert.True(circuits.Count > 0);
        }

        [Fact]
        public async Task Test_Add_Circuit_Should_Return_Ok()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjRJampQeE5wNmtobW5TVXQtZGU4VCJ9.eyJpc3MiOiJodHRwczovL2Rldi16c3JiMDM4ZS5ldS5hdXRoMC5jb20vIiwic3ViIjoiSUNtbFpvTXg5cWdaODJUb2NuOXNIYVo5TUdIQlBjcTRAY2xpZW50cyIsImF1ZCI6Imh0dHA6Ly9mb3JtdWxhMSIsImlhdCI6MTYxOTk2NDAzOCwiZXhwIjoxNjIwMDUwNDM4LCJhenAiOiJJQ21sWm9NeDlxZ1o4MlRvY245c0hhWjlNR0hCUGNxNCIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyJ9.AXAjGIfEf3nMjRgb7qgxyDiVuHp0wDkwn1DnbdB70A49h2AHPYIlX61Qzs_Oiyh4KvEobLPltyUzHmlTSPYE2VeJ2dd9UkCwNhTnn3sDSciDMsiw7VVOsgwXQYC5gG6WRmUIHnySh0pw55V6MXxWPDUzW1_dGm1yG74KpiLCe8HXAwxj_8zBQlrKEzuHlOsWHZGPcNqNNY1yAFMOFcCmtsr8RxnJcIdRCH9UHStO34AZveDqw-aMje_wLS4uFah_mG2mAvLYhxaTFLE5hkrRTTz4sOkGDiZruwTNWbrV7ODUXnD5TcKkPnvsfXhTcPoLara2_H98b51Vi7JQZZCc1w");
            
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
