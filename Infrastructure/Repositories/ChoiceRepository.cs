using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class ChoiceRepository : GenericRepository<Choice>, IChoiceRepository
    {
        private readonly AppDbContext _context;

        public ChoiceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
