using System.Collections.Generic;
using MoviesAPI.Models;
using System.Linq.Expressions;
using System;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Repositories.RepositoryInterface
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<MovieActor> GetMovieByActorId(int actorId);

        IEnumerable<Movie> GetMoviesWithRateAndGenre();

        IEnumerable<Movie> FilterMovies(Expression<Func<Movie , bool>> predicate);
    }
}
