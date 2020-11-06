using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GTracker.Application;
using GTracker.Domain.DTO.User;
using GTracker.Test.Integration.Fixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace GTracker.Test.Integration.Scenario
{
    public class UserControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public UserControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task Login_GiveUser_WhenValidCredentials_ThenOk()
        {   
            // Arrange
            var request = new LoginUserDTO() 
            {
                Login = "admin",
                Password = "senhalegal"
            };

            var myContent = JsonConvert.SerializeObject(request);

            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Assert
            var response = await _client.PostAsync("/gtracker/user/login", byteContent);

            // Assert
            var stringResponse = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResponseUserDTO>(stringResponse);

            loginResponse.Authenticated.Should().BeTrue();
            loginResponse.AccessToken.Should().NotBeNull();
        }

        [Fact]
        public async Task Login_GivenUser_WhenInvalidCredentials_ThenForbiden()
        {
            // Arrange
            var request = new LoginUserDTO()
            {
                Login = "admin",
                Password = "senhaerrada"
            };

            var myContent = JsonConvert.SerializeObject(request);

            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Assert
            var response = await _client.PostAsync("/gtracker/user/login", byteContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}