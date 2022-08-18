using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Services;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private ActorService m_ActorService = new ActorService();

        [HttpGet]
        public IActionResult GetAllActors()
        {
            var list = m_ActorService.GetAllActors();
            return Ok(list);
        }

        [HttpGet("{Id}")]
        public IActionResult GetActorById(int Id)
        {
            var actor = m_ActorService.GetActorById(Id);
            return Ok(actor);
        }

        [HttpPost]
        public IActionResult AddActor([FromBody] ActorVM i_Actor)
        {
            m_ActorService.AddActor(i_Actor);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateActor([FromBody]Actor i_ActorToUpdate, int Id)
        {
            m_ActorService.UpdateActor(i_ActorToUpdate , Id);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult RemoveActor(int Id)
        {
            m_ActorService.RemoveActor(Id);
            return Ok();
        }

        [HttpGet("movie-actors/{Id}")]
        public IActionResult GetActorsOfMovie(int Id)
        {
            var list = m_ActorService.GetActorsOfMovie(Id);
            IActionResult reponse;
            if(list.Count == 0)
            {
                reponse = NoContent();
            }
            else
            {
                reponse = Ok(list);
            }
            return reponse;
            
        }
    }
}
