using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Api_1.Test
{
    public class GetInterestRates
    {
        private readonly IHostBuilder _hostBuilder;
        public GetInterestRates()
        {
            _hostBuilder = new HostBuilder()
           .ConfigureWebHost(webHost =>
           {
               webHost.UseStartup<Api_1.Startup>();
               webHost.UseTestServer();
           });
        }

        [Fact]
        public async Task Teste1()
        {

            var host = await _hostBuilder.StartAsync();
            var client = host.GetTestClient();
            var response = await client.GetAsync("/taxaJuros");
            response.EnsureSuccessStatusCode();
            var responseContent = JObject.Parse(await response.Content.ReadAsStringAsync());
            Assert.Equal("0.01", responseContent.SelectToken("interestRate").Value<string>());
        }
    }
}
