using System;
using System.Threading.Tasks;
using api_1.Resources;
using api_1.Resources.Response;

namespace api_1.Services
{
    public class InterestRateServices : IInterestRateServices
    {
        public async Task<GetInterestRateResponse> GetInterestRate()
        {
            try
            {
                var interestRate = new GetInterestRateResource(){
                    InterestRate = 0.01
                };
                return new GetInterestRateResponse(interestRate);
            }
            catch (Exception ex)
            {
                return new GetInterestRateResponse(ex.Message);
            }
        }
    }
}