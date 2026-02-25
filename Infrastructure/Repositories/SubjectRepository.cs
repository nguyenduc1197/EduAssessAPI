using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
