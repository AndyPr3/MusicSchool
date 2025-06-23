using MediatR;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Commands.StudentCommand
{
    public class StudentDeleteCommandHandler : IRequestHandler<StudentDeleteCommand, int>
    {
        private readonly IStudentRepository _repo;
        public StudentDeleteCommandHandler(IStudentRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(StudentDeleteCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.id);
            if (existing is null)
                throw new($"Student not found with Id {request.id}");

            var result = await _repo.DeleteAsync(request.id);
            return result;
        }
    }
}
