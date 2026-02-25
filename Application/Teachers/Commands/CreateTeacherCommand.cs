using MediatR;
namespace Application.Teachers.Commands
{
    public record CreateTeacherCommand(string name, DateTime dob) : IRequest<Guid>;
}
