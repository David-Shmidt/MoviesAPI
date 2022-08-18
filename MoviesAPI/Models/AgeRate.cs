using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Models
{
    public class AgeRate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Rate { get; set; }
    }
}
