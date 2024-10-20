using AutoMapper;
using BlueberryMuffin.Data;
using BlueberryMuffin.Models;

namespace BlueberryMuffin.Contracts
{

    public interface IQuestionsRepository : IBaseRepository<Question> { }

    public class QuestionsRepository : BaseRepository<Question>, IQuestionsRepository
    {
        private readonly BlueberryDbContext _context;

        public QuestionsRepository(BlueberryDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
    }
}
