using Domain.Entities;
using MediatR;
namespace Application.Questions.Commands
{
    public record CreateQuestionCommand(string content, List<Choice> Choices) : IRequest<Guid>;
}
