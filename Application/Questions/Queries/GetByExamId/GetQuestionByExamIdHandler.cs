using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Questions.Queries.GetByExam
{
    public class GetQuestionByExamIdHandler : IRequestHandler<GetQuestionsByExamIdQuery, List<QuestionDto>>
    {
        private readonly IQuestionRepository _repo;

        private readonly IExamRepository _examRepository;


        public GetQuestionByExamIdHandler(IQuestionRepository repo, IExamRepository examRepository)
        {
            _repo = repo;
            _examRepository = examRepository;
        }

        public async Task<List<QuestionDto>> Handle(GetQuestionsByExamIdQuery request, CancellationToken ct)
        {
            var query = _examRepository.Query();

            var questions = await query
                .Where(x => x.Id == request.ExamId)
                .Include(x => x.Questions)
                .ThenInclude(x => x.Choices)
                .SelectMany(x => x.Questions).ToListAsync();

            return questions.Adapt<List<QuestionDto>>(); ;
        }
    }
}
