using AutoMapper;
using BlueberryMuffin.Data;
using BlueberryMuffin.Models;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Contracts
{
    public interface ICountriesRepository : IBaseRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }

    public class CountriesRepository : BaseRepository<Country>, ICountriesRepository
    {
        private readonly BlueberryDbContext _context;
        public CountriesRepository(BlueberryDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
