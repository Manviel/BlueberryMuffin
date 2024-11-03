using AutoMapper;
using BlueberryMuffin.Data;

namespace BlueberryMuffin.Contracts
{
    public interface IUsersRepository : IBaseRepository<ApiUser> {
        Task<ApiUser> GetByIdAsync(string id);
    }

    public class UsersRepository : BaseRepository<ApiUser>, IUsersRepository
    {
        private readonly BlueberryDbContext _context;

        public UsersRepository(BlueberryDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public async Task<ApiUser> GetByIdAsync(string id)
        {
            if (id is null)
            {
                return null;
            }

            return await _context.Set<ApiUser>().FindAsync(id);
        }
    }
}
