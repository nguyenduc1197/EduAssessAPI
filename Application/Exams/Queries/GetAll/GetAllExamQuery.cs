using Application.DTOs;
using MediatR;

namespace Application.Exams.Queries
{
    public record GetAllExamQuery(int PageNumber = 1, int PageSize = 10) : IRequest<List<ExamDto>>;
}
