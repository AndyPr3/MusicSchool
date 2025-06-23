using MediatR;
using MusicSchool.Application.DTOs;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Queries.InscriptionQueries
{
    public class GetAllInscriptionQueryHandler : IRequestHandler<GetAllInscriptionQuery, List<InscriptionDto>>
    {
        private readonly IInscriptionRepository _repo;
        public GetAllInscriptionQueryHandler(IInscriptionRepository repo)
            => _repo = repo;

        public async Task<List<InscriptionDto>> Handle(
            GetAllInscriptionQuery request,
            CancellationToken ct)
        {
            var schools = await _repo.GetAllAsync();
            return schools.Select(s => new InscriptionDto
            {
                Id = s.Id,
                Student = new StudentDto
                {
                    Id = s.Student.Id,
                    IdentificationNumber = s.Student.IdentificationNumber,
                    FirtsName = s.Student.FirstName,
                    LastName = s.Student.LastName
                },
                Teacher = new TeacherDto
                {
                    Id = s.Teacher.Id,
                    IdentificationNumber = s.Teacher.IdentificationNumber,
                    FirtsName = s.Teacher.FirstName,
                    LastName = s.Teacher.LastName
                },
                AssignedAt = s.AssignedAt,
            }).ToList();
        }
    }
}
