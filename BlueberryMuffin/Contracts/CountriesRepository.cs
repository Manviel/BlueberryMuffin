using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlueberryMuffin.Data;
using BlueberryMuffin.Exceptions;
using BlueberryMuffin.Models;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Contracts
{
    public interface ICountriesRepository : IBaseRepository<Country>
    {
        Task<CountryDetails> GetDetails(int id);
    }

    public class CountriesRepository : BaseRepository<Country>, ICountriesRepository
    {
        private readonly BlueberryDbContext _context;
        private readonly IMapper _mapper;

        public CountriesRepository(BlueberryDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CountryDetails> GetDetails(int id)
        {
            var country = await _context.Countries.Include(q => q.Hotels)
                .ProjectTo<CountryDetails>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (country == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }

            return country;
        }
    }
}
