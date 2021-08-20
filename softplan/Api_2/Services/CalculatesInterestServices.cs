using System;
using System.Threading.Tasks;
using api_2.Resources.Response;
using Api_2.Resources;

namespace api_2.Services
{
    public class CalculatesInterestServices : ICalculatesInterestServices
    {
        private IApi1Services _api1Services;

        public CalculatesInterestServices(IApi1Services api1Services)
        {
            _api1Services = api1Services;
        }
        public async Task<ReturnsAmountWithInterestResponse> ReturnsAmountWithInterest(CalculatesInterestQueryResource query)
        {
            try
            {
                var taxa = await _api1Services.GetInterestRateAsync();
                if (taxa.InterestRate == 0)
                    return new ReturnsAmountWithInterestResponse(taxa.Message);
                var meses = Convert.ToDouble(query.meses);
                var result = Math.Pow(((1 + taxa.InterestRate)), meses) * query.valorinicial;
                result = Convert.ToDouble(result.ToString("#.##"));

                return new ReturnsAmountWithInterestResponse(result);
            }
            catch (Exception ex)
            {
                return new ReturnsAmountWithInterestResponse(ex.Message);
            }
        }
    }
}