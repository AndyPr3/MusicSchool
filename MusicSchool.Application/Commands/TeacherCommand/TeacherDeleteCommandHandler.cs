using MediatR;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Commands.TeacherCommand
{
    public class TeacherDeleteCommandHandler : IRequestHandler<TeacherDeleteCommand, int>
    {
        private readonly ITeacherRepository _repo;
        public TeacherDeleteCommandHandler(ITeacherRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(TeacherDeleteCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.id);
            if (existing is null)
                throw new($"Teacher not found with Id {request.id}");

            var result = await _repo.DeleteAsync(request.id);
            return result;
        }
    }
}
