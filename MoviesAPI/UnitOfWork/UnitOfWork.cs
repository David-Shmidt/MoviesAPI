using MoviesAPI.Models;
using MoviesAPI.Repositories.RepositoryClass;
using MoviesAPI.Repositories.RepositoryInterface;
using MoviesAPI.Services;

namespace MoviesAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MoviesDbContext m_DbContext;

        public UnitOfWork(MoviesDbContext dbContext)
        {
            m_DbContext = dbContext;
            Movies = new MovieRepository(dbContext);
            Actors = new ActorRepository(dbContext);
            Directors = new DirectorRepository(dbContext);
        }

        public IMovieRepository Movies { get; private set; }
        public IActorRepository Actors { get; private set; }
        public IDirectorRepository Directors { get; private set; }

        public int Complete()
        {
            return m_DbContext.SaveChanges();
        }

        public void Dispose()
        {
            m_DbContext.Dispose();
        }

    }
}
