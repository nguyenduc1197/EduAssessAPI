using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Questions.Queries.GetById
{
    public class GetQuestionByIdHandler : IRequestHandler<GetQuestionByIdQuery, Question?>
    {
        private readonly IQuestionRepository _repo;

        public GetQuestionByIdHandler(IQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<Question?> Handle(GetQuestionByIdQuery request, CancellationToken ct)
        {
            return await _repo.GetByIdAsync(request.Id);
        }
    }
}
