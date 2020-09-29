using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using GTracker.Application;
using GTracker.Test.Integration.Config;
using Xunit;

namespace GTracker.Test.Integration
{
    public class GameAPITest
    {
        private readonly IntegrationTestFixture<StartupApiTests> _integrationTestFixture;

        public GameAPITest()
        {
            _integrationTestFixture = new IntegrationTestFixture<StartupApiTests>();
        }

        [Fact]
        public async Task Given_All_Games_When_No_Token_Then_Unauthorized()
        {
            var request = await _integrationTestFixture.Client.GetAsync($"/gtracker/game");
            //var response = await request.Content.ReadAsStringAsync();

            request.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Given_Game_When_No_Token_Then_Unauthorized()
        {
            var request = await _integrationTestFixture.Client.GetAsync($"/gtracker/game/1");
            //var response = await request.Content.ReadAsStringAsync();

            request.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}