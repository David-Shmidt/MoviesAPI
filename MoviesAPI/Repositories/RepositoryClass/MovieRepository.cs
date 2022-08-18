using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using MoviesAPI.Repositories.RepositoryInterface;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Repositories.RepositoryClass
{
    public class MovieRepository : Repository<Movie> , IMovieRepository
    {
        public MovieRepository(MoviesDbContext context)
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

        public IEnumerable<MovieActor> GetMovieByActorId(int i_RequiredActorId)
        {
            return DbContext.MoviesAndActors.Include(ma => ma.Movie).Include(ma => ma.Movie.Genre)
                .Include(ma => ma.Movie.AgeRate).Where(ma => ma.ActorId == i_RequiredActorId).ToList();

        }

        public IEnumerable<Movie> GetMoviesWithRateAndGenre()
        {
            return DbContext.Movies.Include(x => x.AgeRate).Include(x => x.Genre).ToList();
        }

        public IEnumerable<Movie> FilterMovies(Expression<Func<Movie,bool>> predicate)
        {
            return DbContext.Movies.Include(m=>m.Genre).Include(m=>m.AgeRate).Where(predicate).ToList();
        }
    }
}
