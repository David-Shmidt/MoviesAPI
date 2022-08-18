using System.Collections.Generic;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories.RepositoryInterface
{
    public interface IActorRepository : IRepository<Actor>
    {
        IEnumerable<MovieActor> GetActorsByMovie(int i_SelectedMovieId);
    }
}
