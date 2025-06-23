using MediatR;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Commands.SchoolCommand
{
    public class SchoolUpdateCommandHandler : IRequestHandler<SchoolUpdateComand, int>
    {
        private readonly ISchoolRepository _repo;
        public SchoolUpdateCommandHandler(ISchoolRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(SchoolUpdateComand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.Id);
            if (existing is null)
                throw new($"School not found with Id  {request.Id}");

            existing.Code = request.Code;
            existing.Name = request.Name;
            existing.Description = request.Description;

            var result = await _repo.UpdateAsync(existing);
            return result;
        }
    }
}
