using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private GenreService m_GenreService = new GenreService();
        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var list = m_GenreService.GetAllGenres();
            return Ok(list);
        }
    }
}
