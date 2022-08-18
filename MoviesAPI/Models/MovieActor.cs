using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Models
{
    public class MovieActor
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Actors")]
        public int ActorId { get; set; }
        [ForeignKey("Movies")]
        public int MovieId { get; set; }
        [Required]
        public string SalaryOfActor { get; set; }
        
        public Actor Actor { get; set; }

        public Movie Movie { get; set; }
    }
}
