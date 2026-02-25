using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class SchoolClassRepository : GenericRepository<SchoolClass>, ISchoolClassRepository
    {
        private readonly AppDbContext _context;

        public SchoolClassRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
