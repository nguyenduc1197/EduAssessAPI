using Application.DTOs;
using Domain.Entities;
using MediatR;
namespace Application.StudentExamAnswers.Commands.Create
{
    public record CreateStudentExamAnswerCommand(Guid examId, Guid studentId, List<SubmitAnswerDto> answers) : IRequest<bool>;
}
