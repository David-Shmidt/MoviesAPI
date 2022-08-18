using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using MoviesAPI.Repositories.RepositoryInterface;

namespace MoviesAPI.Repositories.RepositoryClass
{
    public class DirectorRepository : Repository<Director>, IDirectorRepository
    {
        public DirectorRepository(MoviesDbContext context)
            : base(context)
        {

        }

        public MoviesDbContext DbContext
        {
            get
            {
                return Context as MoviesDbContext;
            }
        }

        public IEnumerable<Movie> GetMoviesOfDirector(int i_SelectedDirectorId)
        {
            return DbContext.Movies.Where(x => x.DirectorId == i_SelectedDirectorId).ToList();
        }
    }
}
