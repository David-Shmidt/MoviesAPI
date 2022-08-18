using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Models
{
    public class Director
    {
        public Director()
        {
            Movies = new List<Movie>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
