using System;
using System.Net.Http;
using System.Threading.Tasks;
using api_2.Resources.Response;
using Newtonsoft.Json.Linq;

namespace api_2.Services
{
    public class Api1Services : IApi1Services
    {
        private static readonly HttpClient _client = new HttpClient();
        public async Task<GetInterestRateResponse> GetInterestRateAsync()
        {
            try
            {
                var uri = new Uri($"http://localhost:5003/taxaJuros");
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri,
                };
                var result = await _client.SendAsync(request);
                result.EnsureSuccessStatusCode();
             
               var response = JObject.Parse(await result.Content.ReadAsStringAsync());
               var taxa = response.SelectToken("interestRate").Value<double>();
               return new GetInterestRateResponse(taxa);
            }
            catch (Exception ex)
            {
                return new GetInterestRateResponse(ex.Message);
            }
        }

    }
}