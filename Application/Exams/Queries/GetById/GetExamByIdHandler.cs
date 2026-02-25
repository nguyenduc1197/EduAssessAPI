using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Exams.Queries.GetById
{
    public class GetExamByIdHandler : IRequestHandler<GetExamByIdQuery, ExamDto?>
    {
        private readonly IQuestionRepository _repo;

        public GetExamByIdHandler(IQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<ExamDto?> Handle(GetExamByIdQuery request, CancellationToken ct)
        {
            var exam = await _repo.GetByIdAsync(request.Id);

            return exam.Adapt<ExamDto>();
        }
    }
}
