using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Models
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<AgeRate> AgeRates { get; set; }

        public DbSet<MovieActor> MoviesAndActors{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=LAPTOP-6KCL4KKM\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True");
        }
    }
}
