using System.Collections.Generic;
using System.Linq;
using MoviesAPI.Models;
using MoviesAPI.UnitOfWork;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Services
{
    public class DirectorService
    {
        private MoviesDbContext dbContext = new MoviesDbContext();

        private readonly IUnitOfWork r_unitOfWork = new UnitOfWork.UnitOfWork(new MoviesDbContext());

        public List<Director> GetAllDirectors()
        {
            return (List<Director>)r_unitOfWork.Directors.GetAll();
        }

        public void AddDirector(DirectorVM i_Director)
        {
            Director director = new Director()
                                    { Age = i_Director.Age, Name = i_Director.Name, LastName = i_Director.LastName };
            r_unitOfWork.Directors.Add(director);
            r_unitOfWork.Complete();
            //dbContext.Directors.Add(director);
            //dbContext.SaveChanges();
        }

        public void UpdateDirector(DirectorVM i_Director , int i_Id)
        {
            //Director director = dbContext.Directors.Find(i_Id);
            Director director = r_unitOfWork.Directors.GetById(i_Id);
            director.Name = i_Director.Name;
            director.Age = i_Director.Age;
            director.LastName = i_Director.LastName;
            r_unitOfWork.Complete();

            //dbContext.Directors.Update(director);
            //dbContext.SaveChanges();
        }

        public void DeleteDirector(int i_Id)
        {
            Director director = r_unitOfWork.Directors.GetById(i_Id);
            r_unitOfWork.Directors.Remove(director);
            r_unitOfWork.Complete();
            /*Director director = dbContext.Directors.Find(i_Id);
            dbContext.Directors.Remove(director);
            dbContext.SaveChanges();*/
        }

        public List<Movie> GetMovieOfDirector(int i_SelectedDirectorId)
        {
            List<Movie> movies =  (List<Movie>)r_unitOfWork.Directors.GetMoviesOfDirector(i_SelectedDirectorId);
            return movies;
        }
    }
}
