using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private DirectorService m_directorService = new DirectorService();

        [HttpGet]
        public IActionResult GetAllDirectors()
        {
            var list = m_directorService.GetAllDirectors();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddDirector([FromBody]DirectorVM i_Director)
        {
            m_directorService.AddDirector(i_Director);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateDirector([FromBody]DirectorVM i_Director , int Id)
        {
            m_directorService.UpdateDirector(i_Director , Id);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteDirector(int Id)
        {
            m_directorService.DeleteDirector(Id);
            return Ok();
        }

        [HttpGet("movies/{Id}")]
        public IActionResult GetMoviesOfDirector(int Id)
        {
            var list = m_directorService.GetMovieOfDirector(Id);
            return Ok(list);
        }
        
    }
}
