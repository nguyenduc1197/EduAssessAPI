using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly AppDbContext _context;

        public ExamRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
