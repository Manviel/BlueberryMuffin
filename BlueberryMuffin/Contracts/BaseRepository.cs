using BlueberryMuffin.Data;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly BlueberryDbContext _context;

        public BaseRepository(BlueberryDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);

            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);

            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
:   
}
