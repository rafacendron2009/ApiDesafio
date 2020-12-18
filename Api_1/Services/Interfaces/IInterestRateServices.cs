using System.Threading.Tasks;
using api_1.Resources.Response;

namespace api_1.Services
{
    public interface IInterestRateServices
    {
        Task<GetInterestRateResponse> GetInterestRate();
    }
}