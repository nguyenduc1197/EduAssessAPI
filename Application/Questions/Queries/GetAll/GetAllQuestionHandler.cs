using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Questions.Queries
{
    public class GetAllQuestionHandler : IRequestHandler<GetAllQuestionQuery, List<QuestionDto>>
    {
        private readonly IQuestionRepository _repo;

        public GetAllQuestionHandler(IQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<QuestionDto>> Handle(GetAllQuestionQuery request, CancellationToken ct)
        {
            var query = _repo.Query();

            var questions = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize).Include(x => x.Choices)
            .ToListAsync();

            var a = questions.Adapt<List<QuestionDto>>();

            return a;

        }
    }
}
