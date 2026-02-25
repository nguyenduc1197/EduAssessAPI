using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
