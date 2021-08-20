using System.Threading.Tasks;
using api_1.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Api_1.Controllers
{
    [ApiController]
    public class InterestRateController : ControllerBase
    {   
        private readonly IInterestRateServices _interestRateServices;
        public InterestRateController(IInterestRateServices interestRateServices)
        {
            _interestRateServices = interestRateServices;
        }

        [HttpGet]
        [EnableCors]
        [Route("/taxaJuros")]
        public async Task<ActionResult<dynamic>> ListAccountAndRecipes()
        {
            var response = await _interestRateServices.GetInterestRate();
            if (!response.Success)
            {
                return BadRequest(new ProblemDetails()
                {
                    Type = "https://httpstatuses.com/400",
                    Title = ReasonPhrases.GetReasonPhrase(400),
                    Status = 400,
                    Detail = response.Message
                });
            }
            return Ok(response.InterestRate);
        }

    }
}
