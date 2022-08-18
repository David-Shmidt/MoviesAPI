using System;
using MoviesAPI.Repositories.RepositoryInterface;

namespace MoviesAPI.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        IMovieRepository Movies { get; }
        IActorRepository Actors { get; }
        IDirectorRepository Directors { get; }

        int Complete();
    }
}
