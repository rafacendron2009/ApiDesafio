using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Api_2.Test
{
    public class InterestRate
    {

        private readonly IHostBuilder _hostBuilder;
        public InterestRate()
        {
            _hostBuilder = new HostBuilder()
           .ConfigureWebHost(webHost =>
           {
               webHost.UseStartup<Api_2.Startup>();
               webHost.UseTestServer();
           });
        }

        [Fact]
        //para teste funcionar API 1 deve estar em execução
        public async Task CalculoJuros()
        {

            var host = await _hostBuilder.StartAsync();
            var client = host.GetTestClient();
            var content = new StringContent(new JObject()
            {

            }.ToString(), null, null);
            var response = await client.PostAsync("/calculajuros?valorinicial=100&meses=5", null);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Equal("105.1", responseContent);
        }
    }
}
