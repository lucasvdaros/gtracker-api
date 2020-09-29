using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace GTracker.Test.Integration.Config
{
    public class IntegrationTestFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly GTrackerFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions()
            {
                HandleCookies = false,
                BaseAddress = new Uri("http://localhost"),
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 7
            };

            Factory = new GTrackerFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }
        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}