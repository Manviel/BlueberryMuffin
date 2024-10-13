using AutoMapper;
using BlueberryMuffin.Data;
using BlueberryMuffin.Models;

namespace BlueberryMuffin.Contracts
{

    public interface IHotelsRepository : IBaseRepository<Hotel> { }

    public class HotelsRepository : BaseRepository<Hotel>, IHotelsRepository
    {
        private readonly BlueberryDbContext _context;

        public HotelsRepository(BlueberryDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
    }
}
