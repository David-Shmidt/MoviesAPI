using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorController : ControllerBase
    {
        private MovieActorService m_movieActorService = new MovieActorService();

        [HttpGet("movieId={movieId},actorId={actorId}")]
        public IActionResult GetActorAndMovie(int movieId, int actorId)
        {
            var movieActor = m_movieActorService.GetActorAndMovieById( movieId , actorId);
            return Ok(movieActor);
        }

        [HttpPost("movieId={movieId},actorId={actorId},salary={actorSalary}")]
        public IActionResult AddActorMovie(int movieId, int actorId , string actorSalary)
        {
            MovieActor movieActor =  m_movieActorService.AddActorMovie(movieId, actorId ,actorSalary );
            IActionResult response;
            if(movieActor == null)
            {
                response = BadRequest("Requested Actor or Movie not found");
            }
            else
            {
                response = Ok("Added Successfully");
            }
            return response;
        }
    }
}
