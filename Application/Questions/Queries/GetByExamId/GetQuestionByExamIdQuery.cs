using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Questions.Queries.GetByExam
{
    public record GetQuestionsByExamIdQuery(Guid ExamId) : IRequest<List<QuestionDto>>;
}
