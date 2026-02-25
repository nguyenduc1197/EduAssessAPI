using Domain.Entities;
using MediatR;
namespace Application.Exams.Commands
{
    public record CreateExamCommand(string name, DateTime start, DateTime end, List<Guid> questionIds, Guid schoolClassId) : IRequest<Guid>;
}
