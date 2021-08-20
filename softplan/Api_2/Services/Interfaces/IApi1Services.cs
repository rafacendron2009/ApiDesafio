using System.Threading.Tasks;
using api_2.Resources.Response;

namespace api_2.Services
{
    public interface IApi1Services
    {
        Task<GetInterestRateResponse> GetInterestRateAsync();
    }
}