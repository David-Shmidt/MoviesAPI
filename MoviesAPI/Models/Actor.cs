using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Models
{
    public class Actor
    {
        public Actor()
        {
            MoviesActors = new List<MovieActor>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }

        public virtual ICollection<MovieActor> MoviesActors { get; set; }

    }
}
