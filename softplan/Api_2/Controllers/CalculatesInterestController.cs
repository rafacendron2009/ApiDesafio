using System.Threading.Tasks;
using api_2.Services;
using Api_2.Resources;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;

namespace Api_2.Controllers
{
    [ApiController]
    public class InterestRateController : ControllerBase
    {
        private ICalculatesInterestServices _calculatesInterestServices;
        public InterestRateController(ICalculatesInterestServices calculatesInterestServices)
        {
            _calculatesInterestServices = calculatesInterestServices;
        }

        [HttpPost]
        [EnableCors]
        [Route("/calculajuros")]
        public async Task<ActionResult<dynamic>> CalculatesInterest([BindRequired, FromQuery] CalculatesInterestQueryResource querys)
        {
            var response = await _calculatesInterestServices.ReturnsAmountWithInterest(querys);
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
            return Ok(response.Total);
        }

    }
}

