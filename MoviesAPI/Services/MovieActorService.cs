using System.Linq;
using MoviesAPI.Models;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Services
{
    public class MovieActorService
    {
        private MoviesDbContext db = new MoviesDbContext();

        public MovieActorVM GetActorAndMovieById(int i_MovieId, int i_ActorId)
        {
            var list = db.MoviesAndActors.Where(ma => ma.ActorId == i_ActorId && ma.MovieId == i_MovieId)
                .Select(
                    ma => new MovieActorVM()
                              {
                                  MovieName = ma.Movie.Name,
                                  ActorName = ma.Actor.Name + ma.Actor.LastName
                              });
            MovieActorVM movieActor = new MovieActorVM();
            foreach(var item in list)
            {
                 movieActor = new MovieActorVM() { ActorName = item.ActorName, MovieName = item.MovieName };
            }
            return movieActor;
        }

        public MovieActor AddActorMovie(int movieId, int actorId , string actorSalary)
        {
            Actor actor = db.Actors.Find(actorId);
            Movie movie = db.Movies.Find(movieId);
            MovieActor movieActor = new MovieActor();
            if(actor == null || movie == null)
            {
                movieActor = null;
            }
            else
            {
                movieActor = new MovieActor() { ActorId = actorId, MovieId = movieId , SalaryOfActor = actorSalary};
                db.MoviesAndActors.Add(movieActor);
                db.SaveChanges();
            }
            return movieActor;

        }
    }
}
