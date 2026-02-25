using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Questions.Commands
{
    public class CreateQuestionHandler : IRequestHandler<CreateQuestionCommand, Guid>
    {
        private readonly IQuestionRepository _questionRepo;

        private readonly IChoiceRepository _choiceRepository;

        private readonly IUnitOfWork _unitOfWork;
        public CreateQuestionHandler(IQuestionRepository questionRepo, IChoiceRepository choiceRepository, IUnitOfWork unitOfWork)
        {
            _questionRepo = questionRepo;
            _choiceRepository = choiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateQuestionCommand request, CancellationToken ct)
        {
            var choices = request.Choices ?? new List<Choice>();

            var question = new Question
            {
                Content = request.content,
                Choices = choices.Select(x => new Choice
                {
                    OptionLabel = x.OptionLabel,
                    Content = x.Content,
                    IsCorrect = x.IsCorrect
                }).ToList()
            };

            await _questionRepo.AddAsync(question);

            await _unitOfWork.SaveChangesAsync(ct);

            return question.Id;
        }
    }
}
