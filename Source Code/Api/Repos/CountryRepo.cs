using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repos
{
    public class CountryRepo : ICountryRepo
    {
        private readonly ApplicationDbContext _context;

        public CountryRepo(ApplicationDbContext context)
        { 
            _context = context;
        }

        public List<Country> GetAll(int skip, int batchSize)
        {
            return _context.Countries.AsNoTracking().Skip(skip).Take(batchSize).ToList();
        }

        public int Total()
        {
            return _context.Countries.AsNoTracking().Count();
        }
    }
}
