using MediatR;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Commands.SchoolCommand
{
    public class SchoolDeleteCommandHandler : IRequestHandler<SchoolDeleteCommand, int>
    {
        private readonly ISchoolRepository _repo;
        public SchoolDeleteCommandHandler(ISchoolRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(SchoolDeleteCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.id);
            if (existing is null)
                throw new($"School not found with Id {request.id}");

            var result = await _repo.DeleteAsync(request.id);
            return result;
        }
    }
}
