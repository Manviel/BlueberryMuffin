using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlueberryMuffin.Data;
using BlueberryMuffin.Exceptions;
using BlueberryMuffin.Models;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Contracts
{
    public interface ISurveysRepository : IBaseRepository<Survey>
    {
        Task<SurveyDetails> GetDetails(int id);
    }

    public class SurveysRepository : BaseRepository<Survey>, ISurveysRepository
    {
        private readonly BlueberryDbContext _context;
        private readonly IMapper _mapper;

        public SurveysRepository(BlueberryDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SurveyDetails> GetDetails(int id)
        {
            var country = await _context.Surveys.Include(q => q.Hotels)
                .ProjectTo<SurveyDetails>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (country == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }

            return country;
        }
    }
}
