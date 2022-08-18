using System.Collections.Generic;
using System.Linq;
using MoviesAPI.Models;

namespace MoviesAPI.Services
{
    public class GenreService
    {
        private MoviesDbContext dbContext = new MoviesDbContext();

        public List<Genre> GetAllGenres()
        {
            return dbContext.Genres.ToList();
        }
    }
}
