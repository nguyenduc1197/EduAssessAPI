using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class StudentExamRepository : GenericRepository<StudentExam>, IStudentExamRepository
    {
        private readonly AppDbContext _context;

        public StudentExamRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
