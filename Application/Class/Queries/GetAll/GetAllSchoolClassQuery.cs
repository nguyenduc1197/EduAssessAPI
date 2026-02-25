using Application.DTOs;
using MediatR;

namespace Application.Class.Queries
{
    public record GetAllSchoolClassQuery(int PageNumber = 1, int PageSize = 10) : IRequest<List<ClassDto>>;
}
