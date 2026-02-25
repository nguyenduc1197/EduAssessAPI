using Application.DTOs;
using Application.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Exams.Queries
{
    public class GetAllExamHandler : IRequestHandler<GetAllExamQuery, List<ExamDto>>
    {
        private readonly IExamRepository _repo;

        public GetAllExamHandler(IExamRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ExamDto>> Handle(GetAllExamQuery request, CancellationToken ct)
        {
            var query = _repo.Query();

            var questions = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize).Where(x => !x.IsDeleted)
            .ToListAsync();

            var exams = questions.Adapt<List<ExamDto>>();

            return exams;

        }
    }
}
