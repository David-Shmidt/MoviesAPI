using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeRateController : ControllerBase
    {
        private AgeRareService m_ageRateService = new AgeRareService();

        [HttpGet]
        public IActionResult GetAllAgeRates()
        {
            var list = m_ageRateService.GetAllAgeRates();
            return Ok(list);
        }
    }
}
