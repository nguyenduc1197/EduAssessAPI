using Application.DTOs;
using Domain.Entities;
using MediatR;
namespace Application.Exams.Commands
{
    public record DeleteExamCommand(Guid Id) : IRequest<bool>;
}
