using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Teachers.Commands
{
    public class CreateTeacherHandler : IRequestHandler<CreateTeacherCommand, Guid>
    {
        private readonly ITeacherRepository _repo;

        private readonly IUnitOfWork _unitOfWork;
        public CreateTeacherHandler(ITeacherRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateTeacherCommand request, CancellationToken ct)
        {
            var teacher = new Teacher { Name = request.name, DateOfBirth = request.dob };

            await _repo.AddAsync(teacher);

            await _unitOfWork.SaveChangesAsync();

            return teacher.Id;
        }
    }
}
