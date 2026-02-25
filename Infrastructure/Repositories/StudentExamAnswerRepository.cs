using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class StudentExamAnswerRepository : GenericRepository<StudentExamAnswer>, IStudentExamAnswerRepository
    {
        private readonly AppDbContext _context;

        public StudentExamAnswerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
