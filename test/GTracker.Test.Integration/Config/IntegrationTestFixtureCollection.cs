using GTracker.Application;
using Xunit;

namespace GTracker.Test.Integration.Config
{
    [CollectionDefinition(nameof(IntegrationTestFixtureCollection))]
    public class IntegrationTestFixtureCollection : ICollectionFixture<IntegrationTestFixture<StartupApiTests>>
    {

    }
}