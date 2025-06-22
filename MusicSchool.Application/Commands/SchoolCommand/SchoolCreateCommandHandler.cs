using MediatR;
using MusicSchool.Domain.Entities;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Commands.SchoolCommand
{
    public class SchoolCreateCommandHandler : IRequestHandler<SchoolCreateComand, int>
    {
        private readonly ISchoolRepository _schoolRepository;
        public SchoolCreateCommandHandler(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public async Task<int> Handle(SchoolCreateComand request, CancellationToken cancellationToken)
        {
            var entity = new School()
            {
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
            };
            return await _schoolRepository.AddAsync(entity);
        }
    }
}
