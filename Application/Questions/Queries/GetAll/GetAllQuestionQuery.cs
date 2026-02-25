using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Questions.Queries
{
    public record GetAllQuestionQuery(int PageNumber = 1, int PageSize = 10) : IRequest<List<QuestionDto>>;
}
