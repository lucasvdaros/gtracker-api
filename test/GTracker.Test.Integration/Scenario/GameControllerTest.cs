using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GTracker.Application;
using GTracker.Domain.Core.Notification;
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
            var game = JsonConvert.DeserializeObject<GameDTO>(await response.Content.ReadAsStringAsync());

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            game.Should().NotBeNull();
            game.Id.Should().Be(2);
        }

        [Fact]
        public async Task Post_GivenGame_WhenNoToken_ThenUnauhorizedResponse()
        {
            // Arrange
            var newGame = new CreateGameDTO
            {
                Name = "FIFA",
                AcquisicionDate = DateTime.Now.AddDays(-30),
                Kind = "1",
                Observation = "UM jogo muito legal"
            };

            var myContent = JsonConvert.SerializeObject(newGame);

            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await _client.PostAsync("/gtracker/game", byteContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Post_GivenGame_WhenAuthorized_ThenAcceptResponse()
        {
            // Arrange
            var newGame = new CreateGameDTO
            {
                Name = "FIFA",
                AcquisicionDate = DateTime.Now.AddDays(-30),
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
        
        [Fact]
        public async Task Post_GivenGame_WhenInvalid_ThenBadRequestResponse()
        {
            // Arrange
            var newGame = new CreateGameDTO
            {
                Name = string.Empty,
                AcquisicionDate = null,
                Kind = "99",
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
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_GivenGames_WhenNoToken_ThenUnauhorizedResponse()
        {
            // Act
            var response = await _client.GetAsync("/gtracker/game");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Get_GivenGames_WhenAuthorized_ThenOkResponse()
        {
            // Arrage
            var token = await GetToken();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.GetAsync("/gtracker/game");
            var itens = JsonConvert.DeserializeObject<List<GameDTO>>(await response.Content.ReadAsStringAsync());

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            itens.Should().NotBeNull();
            itens.Count.Should().BeGreaterThan(1);
        }

        [Fact]
        public async Task Put_GivenGame_WhenNoToken_ThenAcceptResponse()
        {
            // Arrage  
            UpdateGameDTO gameUpdated = new UpdateGameDTO
            {
                AcquisicionDate = DateTime.Now,
                Kind = 1,
                Name = "Tentativa de atualizar nome",
                Observation = "Ajsutando observação de atualização desse game"
            };

            var myContent = JsonConvert.SerializeObject(gameUpdated, Formatting.Indented);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await _client.PutAsync("/gtracker/game/2", byteContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Put_GivenGame_WhenAuthorized_ThenAcceptResponse()
        {
            // Arrage
            var token = await GetToken();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseGame = await _client.GetAsync("/gtracker/game/2");
            var game = JsonConvert.DeserializeObject<GameDTO>(await responseGame.Content.ReadAsStringAsync());

            UpdateGameDTO gameUpdated = new UpdateGameDTO
            {
                AcquisicionDate = game.AcquisicionDate,
                Kind = game.Kind,
                Name = game.Name,
                Observation = "Ajsutando observação de atualização desse game"
            };

            var myContent = JsonConvert.SerializeObject(gameUpdated, Formatting.Indented);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await _client.PutAsync("/gtracker/game/2", byteContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Accepted);
        }

        [Theory]
        [InlineData(null, 2, "Fifa 2021", "Uma observação sobre o jogo", 1)]
        [InlineData(null, 2, "Fifa 2021", "", 1)]
        [InlineData("2020-11-06",1,null, "Uma observação sobre o jogo", 1)]
        [InlineData("2020-11-06", 1, null, "", 1)]
        [InlineData(null, -1, null, "Uma observação sobre o jogo", 2)]
        public async Task Put_GivenGame_WhenInvalid_ThenBadRequestResponse(string acquisicionDate, int kind, string name, string observation, int qntErrors)
        {
            // Arrage
            var token = await GetToken();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            DateTime result;
            DateTime? finalDate = null;
            if(DateTime.TryParse(acquisicionDate, out result))
            {
                finalDate = result;
            }           

            UpdateGameDTO gameUpdated = new UpdateGameDTO
            {
                AcquisicionDate = finalDate,
                Kind = kind,
                Name = name,
                Observation = observation
            };

            var myContent = JsonConvert.SerializeObject(gameUpdated, Formatting.Indented);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await _client.PutAsync("/gtracker/game/2", byteContent);
            var notifications = JsonConvert.DeserializeObject<List<DomainNotification>>(await response.Content.ReadAsStringAsync());

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            notifications.Should().HaveCount(qntErrors);
        }
    }
}