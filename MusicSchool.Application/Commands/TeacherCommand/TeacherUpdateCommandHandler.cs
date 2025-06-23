using MediatR;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Commands.TeacherCommand
{
    public class TeacherUpdateCommandHandler : IRequestHandler<TeacherUpdateComand, int>
    {
        private readonly ITeacherRepository _repo;
        public TeacherUpdateCommandHandler(ITeacherRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(TeacherUpdateComand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.Id);
            if (existing is null)
                throw new($"Teacher not found with Id  {request.Id}");

            existing.IdentificationNumber = request.IdentificationNumber;
            existing.FirstName = request.FirstName;
            existing.LastName = request.LastName;
            existing.SchoolId = request.SchoolId;

            var result = await _repo.UpdateAsync(existing);
            return result;
        }
    }
}
