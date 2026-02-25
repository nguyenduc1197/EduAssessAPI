using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Exams.Commands
{
    public class DeleteExamHandler : IRequestHandler<DeleteExamCommand, bool>
    {
        private readonly IExamRepository _examRepository;

        private readonly IStudentExamRepository _studentExamRepository;

        private readonly IUnitOfWork _unitOfWork;
        public DeleteExamHandler(
            IExamRepository examRepository, 
            IStudentExamRepository studentExamRepository,
            IUnitOfWork unitOfWork)
        {
            _examRepository = examRepository;
            _studentExamRepository = studentExamRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteExamCommand request, CancellationToken ct)
        {
            var exam = await _examRepository.GetByIdAsync(request.Id);

            if (exam == null)
                return false;

            exam.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
