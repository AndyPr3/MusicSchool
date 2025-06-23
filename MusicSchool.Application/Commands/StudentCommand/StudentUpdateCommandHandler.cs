using MediatR;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Commands.StudentCommand
{
    public class StudentUpdateCommandHandler : IRequestHandler<StudentUpdateComand, int>
    {
        private readonly IStudentRepository _repo;
        public StudentUpdateCommandHandler(IStudentRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(StudentUpdateComand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.Id);
            if (existing is null)
                throw new($"Student not found with Id  {request.Id}");

            existing.IdentificationNumber = request.IdentificationNumber;
            existing.FirstName = request.FirstName;
            existing.LastName = request.LastName;
            existing.Birthdate = request.Birthdate;

            var result = await _repo.UpdateAsync(existing);
            return result;
        }
    }
}
