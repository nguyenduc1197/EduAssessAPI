using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
