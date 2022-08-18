using System.Collections.Generic;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories.RepositoryInterface
{
    public interface IDirectorRepository : IRepository<Director>
    {
        IEnumerable<Movie> GetMoviesOfDirector(int i_SelectedDirectorId);
    }
}
