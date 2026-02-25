using Domain.Entities;
using MediatR;

namespace Application.Questions.Queries.GetById
{
    public record GetQuestionByIdQuery(Guid Id) : IRequest<Question?>;
}
