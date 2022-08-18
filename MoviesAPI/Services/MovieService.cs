using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using MoviesAPI.Repositories.RepositoryClass;
using MoviesAPI.Repositories.RepositoryInterface;
using MoviesAPI.UnitOfWork;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Services
{
    public class MovieService
    {
        private MoviesDbContext db = new MoviesDbContext();

        private readonly IUnitOfWork r_UnitOfWork = new UnitOfWork.UnitOfWork(new MoviesDbContext());

        public Movie GetMovieById(int Id)
        {
            //return db.Movies.Find(Id);
            return r_UnitOfWork.Movies.GetById(Id);
        }

        public void AddMovie(Movie i_Movie)
        {
            Movie movie = new Movie()
                              {
                                  Name = i_Movie.Name,
                                  AgeRateId = i_Movie.AgeRateId,
                                  BoxOffice = i_Movie.BoxOffice,
                                  Budget = i_Movie.Budget,
                                  DirectorId = i_Movie.DirectorId,
                                  GenreId = i_Movie.GenreId,
                              };
            
            r_UnitOfWork.Movies.Add(movie);
            r_UnitOfWork.Complete();

            //db.Movies.Add(movie);
            //db.SaveChanges();
        }

        public List<FullMovieDetailsVM> GetAllMovies()
        {
            IEnumerable<Movie> joinedDetails = r_UnitOfWork.Movies.GetMoviesWithRateAndGenre();
            List<FullMovieDetailsVM> fullMovieDetails = fillMovieDetails(joinedDetails as List<Movie>);
            return fullMovieDetails;
        }

        public void UpdateMovieById(Movie updatedMovie , int Id)
        {
            Movie movie = r_UnitOfWork.Movies.GetById(Id);
            movie.Name = updatedMovie.Name;
            movie.AgeRateId = updatedMovie.AgeRateId;
            movie.BoxOffice = updatedMovie.BoxOffice;
            movie.Budget = updatedMovie.Budget;
            movie.DirectorId = updatedMovie.DirectorId;
            movie.GenreId = updatedMovie.GenreId;

            r_UnitOfWork.Complete();

            //db.Movies.Update(movie);
            //db.SaveChanges();
        }

        public void DeleteMovieById(int Id)
        {
            Movie movie = r_UnitOfWork.Movies.GetById(Id);
            r_UnitOfWork.Movies.Remove(movie);
            r_UnitOfWork.Complete();
        }

        
        public List<FullMovieDetailsVM> GetMoviesByGenre(int i_GenreId)
        {
            IEnumerable<Movie> filteredMovies = r_UnitOfWork.Movies.FilterMovies(m=>m.GenreId == i_GenreId);
            List<FullMovieDetailsVM> moviesList = fillMovieDetails(filteredMovies as List<Movie>);
            return moviesList;
        }

        //Gets the Movies of a specific actor
        public List<FullMovieDetailsVM> GetMoviesByActorId(int i_RequiredActorId)
        {
            IEnumerable<MovieActor> list = r_UnitOfWork.Movies.GetMovieByActorId(i_RequiredActorId);
            List<FullMovieDetailsVM> moviesList = new List<FullMovieDetailsVM>();
            foreach(var item in list)
            {
                FullMovieDetailsVM movieDetails = new FullMovieDetailsVM();
                movieDetails.Id = item.MovieId;
                movieDetails.AgeRateId = item.Movie.AgeRateId;
                movieDetails.GenreId = item.Movie.GenreId;
                movieDetails.Name = item.Movie.Name;
                movieDetails.GenreName = item.Movie.Genre.GenreName;
                movieDetails.AgeRate = item.Movie.AgeRate.Rate;
                movieDetails.Budget = item.Movie.Budget;
                movieDetails.BoxOffice = item.Movie.BoxOffice;
                moviesList.Add(movieDetails);
            }
            return moviesList;
        }

        private List<FullMovieDetailsVM> fillMovieDetails(List<Movie> details)
        {
           List<FullMovieDetailsVM> fullMovieDetails = new List<FullMovieDetailsVM>();
            foreach(var item in details)
            {
                FullMovieDetailsVM fullDetails = new FullMovieDetailsVM();
                fullDetails.Id = item.Id;
                fullDetails.AgeRateId = item.AgeRateId;
                fullDetails.GenreId = item.GenreId;
                fullDetails.Name = item.Name;
                fullDetails.GenreName = item.Genre.GenreName;
                fullDetails.AgeRate = item.AgeRate.Rate;
                fullDetails.Budget = item.Budget;
                fullDetails.BoxOffice = item.BoxOffice;
                fullMovieDetails.Add(fullDetails);
            }
            return fullMovieDetails;
        }

       
    }
}

