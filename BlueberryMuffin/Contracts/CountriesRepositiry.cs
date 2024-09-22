using BlueberryMuffin.Data;
using BlueberryMuffin.Models;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Contracts
{
    public interface ICountriesRepositiry : IBaseRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }

    public class CountriesRepository : BaseRepository<Country>, ICountriesRepositiry
    {
        private readonly BlueberryDbContext _context;

        public CountriesRepository(BlueberryDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
