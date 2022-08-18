using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesAPI.Models;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieService m_MovieService = new MovieService();

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var list = m_MovieService.GetAllMovies();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            Movie movie = m_MovieService.GetMovieById(id);
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody]Movie i_Movie)
        {
            m_MovieService.AddMovie(i_Movie);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateMovieById([FromBody]Movie movie , int id)
        {
            m_MovieService.UpdateMovieById(movie , id);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteMovieById(int Id)
        {
            m_MovieService.DeleteMovieById(Id);
            return Ok();
        }

        [HttpGet("Genre/{GenreId}")]
        public IActionResult GetMoviesByGenre(int GenreId)
        {
            var list = m_MovieService.GetMoviesByGenre(GenreId);
            return Ok(list);
        }

        [HttpGet("actor-movies/{Id}")]
        public IActionResult GetMoviesOfActor(int Id)
        {
            var list = m_MovieService.GetMoviesByActorId(Id);
            return Ok(list);
        }

  
    }
}
