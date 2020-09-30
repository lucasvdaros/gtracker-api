using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GTracker.Application;
using GTracker.Domain.DTO.Game;
using GTracker.Domain.DTO.User;
using GTracker.Test.Integration.Fixture;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace GTracker.Test.Integration.Scenario
{
    public class GameControllerTest :
        IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GameControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        public async Task<string> GetToken()
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

            return loginResponse.AccessToken;
        }

        [Fact]
        public async Task GetById_GivenId_WhenNoToken_ThenUnauthorizedResponse()
        {
            // Act
            var response = await _client.GetAsync("/gtracker/game/2");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task GetById_GivenId_WhenAuthorized_ThenOkResponse()
        {
            // Arrage
            var token = await GetToken();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.GetAsync("/gtracker/game/2");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Post_GivenGame_WhenValid_ThenAcceptResponse()
        {
            // Arrange
            var newGame = new CreateGameDTO
            {
                Name = "FIFA",
                AquisicionDate = DateTime.Now.AddDays(-30),
                Kind = "1",
                Observation = "UM jogo muito legal"
            };

            var myContent = JsonConvert.SerializeObject(newGame);

            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var token = await GetToken();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.PostAsync("/gtracker/game", byteContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Accepted);
        }
    }
}