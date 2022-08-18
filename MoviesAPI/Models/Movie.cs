using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Models
{
    public class Movie
    {
        public Movie()
        {
            MoviesActors = new List<MovieActor>();
        }
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("Director")] public int DirectorId { get; set; }

        [ForeignKey("Genre")] public int GenreId { get; set; }

        [ForeignKey("AgeRate")] public int AgeRateId { get; set; }

        [Required] public string Budget { get; set; }

        [Required] public string BoxOffice { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public virtual Director Director { get; set; }

        public virtual ICollection<MovieActor> MoviesActors { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual AgeRate AgeRate { get; set; }
    }
}
