

using Application.Interfaces;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context,
                          IQuestionRepository questionRepo)
        {
            _context = context;
            Questions = questionRepo;
        }

        public IQuestionRepository Questions { get; }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await _context.SaveChangesAsync(ct);
        }
    }
}
