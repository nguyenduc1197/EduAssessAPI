using Application.DTOs;
using Application.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Class.Queries
{
    public class GetAllSchoolClassHandler : IRequestHandler<GetAllSchoolClassQuery, List<ClassDto>>
    {
        private readonly ISchoolClassRepository _repo;

        public GetAllSchoolClassHandler(ISchoolClassRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ClassDto>> Handle(GetAllSchoolClassQuery request, CancellationToken ct)
        {
            var query = _repo.Query();

            var classes = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

            var a = classes.Adapt<List<ClassDto>>();

            return a;

        }
    }
}
