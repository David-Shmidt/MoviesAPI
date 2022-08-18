using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesAPI.Models;

namespace MoviesAPI.ViewModels
{
    public class MovieVM
    {
        public int GenreId { get; set; }

        public string MovieName { get; set; }

        public string Rate { get; set; }

        public string GenreName { get; set; }
    }

    public class PartialMovieDetailsVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AgeRate { get; set; }

        public string Budget { get; set; }

        public string BoxOffice{ get; set; }
    }

    public class FullMovieDetailsVM
    {
        public int Id { get; set; }

        public int AgeRateId { get; set; }

        public int GenreId { get; set; }

        public string Name { get; set; }

        public string GenreName  { get; set; }

        public string AgeRate { get; set; }

        public string Budget { get; set; }

        public string BoxOffice{ get; set; }
    }

    public class MovieNameWithGenreVM
    {
        public string MovieName { get; set; }

        public string GenreName { get; set; }
    }
}
