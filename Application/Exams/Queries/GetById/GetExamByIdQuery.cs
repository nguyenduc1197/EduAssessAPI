using Application.DTOs;
using MediatR;

namespace Application.Exams.Queries.GetById
{
    public record GetExamByIdQuery(Guid Id) : IRequest<ExamDto?>;
}
