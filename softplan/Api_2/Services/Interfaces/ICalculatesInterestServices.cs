using System.Threading.Tasks;
using api_2.Resources.Response;
using Api_2.Resources;

namespace api_2.Services
{
    public interface ICalculatesInterestServices
    {
        Task<ReturnsAmountWithInterestResponse> ReturnsAmountWithInterest(CalculatesInterestQueryResource query);
    }
}