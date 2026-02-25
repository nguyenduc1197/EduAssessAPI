using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Exams.Commands.Create
{
    public class CreateExamHandler : IRequestHandler<CreateExamCommand, Guid>
    {
        private readonly IQuestionRepository _questionRepo;

        private readonly IExamRepository _examRepository;

        private readonly ISubjectRepository _subjectRepository;

        private readonly ISchoolClassRepository _schoolClassRepository;

        private readonly IStudentRepository _studentRepository;

        private readonly IStudentExamRepository _studentExamRepository;

        private readonly IUnitOfWork _unitOfWork;
        public CreateExamHandler(
            IQuestionRepository questionRepo,
            IExamRepository examRepository,
            ISubjectRepository subjectRepository,
            ISchoolClassRepository schoolClassRepository,
            IStudentRepository studentRepository,
            IStudentExamRepository studentExamRepository,
            IUnitOfWork unitOfWork)
        {
            _questionRepo = questionRepo;
            _examRepository = examRepository;
            _subjectRepository = subjectRepository;
            _schoolClassRepository = schoolClassRepository;
            _studentRepository = studentRepository;
            _studentExamRepository = studentExamRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateExamCommand request, CancellationToken ct)
        {
            var questions = await _questionRepo.GetAllAsync();
            var subject = await _subjectRepository.GetByIdAsync(new Guid("f2ada513-2944-42b3-8477-2d4f4ac460c2"));

            var schoolClass = await _schoolClassRepository.GetByIdAsync(request.schoolClassId);

            var exam = new Exam
            {
                Name = request.name,
                Subject = subject,
                SchoolClass = schoolClass,
                Start = request.start,
                End = request.end,
                Questions = questions.Where(x => request.questionIds.Contains(x.Id)).ToList()
            };


            await _examRepository.AddAsync(exam);

            if (schoolClass != null)
            {
                var studentQuery = _studentRepository.Query();

                var students = await studentQuery.Where(x => x.SchoolClassId == schoolClass.Id).ToListAsync();

                students.ForEach(async x =>
                {
                    await _studentExamRepository.AddAsync(new StudentExam
                    {
                        Exam = exam,
                        Student = x
                    });
                });
            }

            await _unitOfWork.SaveChangesAsync(ct);

            return exam.Id;
        }
    }
}
