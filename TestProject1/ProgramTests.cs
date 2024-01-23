using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ASPPROJEKT.Tests
{
    public class ProgramTests : IClassFixture<WebApplicationFactory<ASPPROJEKT.Program>>
    {
        private readonly WebApplicationFactory<ASPPROJEKT.Program> _factory;

        public ProgramTests(WebApplicationFactory<ASPPROJEKT.Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Program_StartsSuccessfully()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/"); // Replace "/" with your application route

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
