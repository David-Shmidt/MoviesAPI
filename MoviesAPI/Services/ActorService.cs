using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using MoviesAPI.UnitOfWork;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Services
{
    public class ActorService
    {
        private MoviesDbContext db = new MoviesDbContext();

        private readonly IUnitOfWork r_unitOfWork = new UnitOfWork.UnitOfWork(new MoviesDbContext());

        public Actor GetActorById(int Id)
        {
            return r_unitOfWork.Actors.GetById(Id);
        }

        public void AddActor(ActorVM i_Actor)
        {
            Actor actor = new Actor()
                              {
                                  Name = i_Actor.Name,
                                  LastName = i_Actor.LastName
                              };
            r_unitOfWork.Actors.Add(actor);
            r_unitOfWork.Complete();
        }

        public void UpdateActor(Actor i_UpdatedActor , int Id)
        {
            Actor actor = r_unitOfWork.Actors.GetById(Id);
            actor.Name = i_UpdatedActor.Name;
            actor.LastName = i_UpdatedActor.LastName;
            r_unitOfWork.Complete();
        }

        public void RemoveActor(int Id)
        {
            Actor actor = r_unitOfWork.Actors.GetById(Id);
            r_unitOfWork.Actors.Remove(actor);
            r_unitOfWork.Complete();
        }

       // Gets Actors Of a specific movie
       public List<ActorVM> GetActorsOfMovie(int i_RequiredMovieId)
       {
           IEnumerable<MovieActor> listOfActors = r_unitOfWork.Actors.GetActorsByMovie(i_RequiredMovieId);
           List<ActorVM> actorsList = new List<ActorVM>();
           foreach(var item in listOfActors)
           {
               ActorVM actor = new ActorVM() {Id = item.ActorId, Name = item.Actor.Name, LastName = item.Actor.LastName };
               actorsList.Add(actor);
           }
           return actorsList;
       }

       public List<Actor> GetAllActors()
       {
           return (List<Actor>)r_unitOfWork.Actors.GetAll();
       }


    }
}
