using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.StudentExamAnswers.Commands.Create
{
    public class CreateStudentExamAnswerCommandHandler : IRequestHandler<CreateStudentExamAnswerCommand, bool>
    {
        private readonly IStudentExamRepository _studentExamRepository;

        private readonly IQuestionRepository _questionRepository;

        private readonly IStudentExamAnswerRepository _studentExamAnswerRepository;

        private readonly IUnitOfWork _unitOfWork;
        public CreateStudentExamAnswerCommandHandler(
            IStudentExamRepository studentExamRepository,
            IStudentExamAnswerRepository studentExamAnswerRepository,
            IQuestionRepository questionRepository,
            IUnitOfWork unitOfWork)
        {
            _studentExamRepository = studentExamRepository;
            _studentExamAnswerRepository = studentExamAnswerRepository;
            _questionRepository = questionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateStudentExamAnswerCommand request, CancellationToken ct)
        {
            foreach (var answer in request.answers)
            {

                var studentExam = await _studentExamRepository.Query()
                                                              .Include(x => x.Student)
                                                              .Include(x => x.Exam)
                                                              .ThenInclude(x => x.Questions)
                                                              .ThenInclude(x => x.Choices)
                                                              .FirstOrDefaultAsync(x => 
                                                              x.Exam != null 
                                                              && x.Student != null 
                                                              && x.Exam.Id == request.examId 
                                                              && x.Student.Id == request.studentId);

                if (studentExam == null || studentExam.Exam == null)
                    continue;


                var question = studentExam.Exam.Questions.FirstOrDefault(x => x.Id == answer.QuestionId);

                if (question == null || question.Choices == null)
                    continue;

                var choice = question.Choices.FirstOrDefault(x => x.Id == answer.ChoiceId);

                await _studentExamAnswerRepository.AddAsync(new StudentExamAnswer
                {
                   StudentExam = studentExam,
                   Question = question,
                   Choice = choice,
               });
            }

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
