using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api_2.Controllers
{
    [ApiController]
    public class ProjectController : ControllerBase
    {

        [HttpGet]
        [EnableCors]
        [Route("/showmethecode")]
        public async Task<ActionResult<dynamic>> GetPathGit()
        {
            return Ok(new {
                Url = "https://github.com/rafacendron2009/ApiDesafio"
            });
        }

    }
}

