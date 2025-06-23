using MediatR;
using MusicSchool.Domain.Entities;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Commands.TeacherCommand
{
    public class TeacherCreateCommandHandler : IRequestHandler<TeacherCreateComand, int>
    {
        private readonly ITeacherRepository _TeacherRepository;
        public TeacherCreateCommandHandler(ITeacherRepository TeacherRepository)
        {
            _TeacherRepository = TeacherRepository;
        }

        public async Task<int> Handle(TeacherCreateComand request, CancellationToken cancellationToken)
        {
            var entity = new Teacher()
            {
                IdentificationNumber = request.IdentificationNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                SchoolId = request.SchoolId
            };
            return await _TeacherRepository.AddAsync(entity);
        }
    }
}
