using System.Collections.Generic;
using System.Linq;
using MoviesAPI.Models;

namespace MoviesAPI.Services
{
    public class AgeRareService
    {
        private MoviesDbContext dbContext = new MoviesDbContext();

        public List<AgeRate> GetAllAgeRates()
        {
            return dbContext.AgeRates.ToList();
        }
    }
}
