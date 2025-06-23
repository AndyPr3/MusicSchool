using MediatR;
using MusicSchool.Application.DTOs;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Queries.StudentQueries
{
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, List<StudentDto>>
    {
        private readonly IStudentRepository _repo;
        public GetAllStudentQueryHandler(IStudentRepository repo)
            => _repo = repo;

        public async Task<List<StudentDto>> Handle(
            GetAllStudentQuery request,
            CancellationToken ct)
        {
            var schools = await _repo.GetAllAsync();
            return schools.Select(s => new StudentDto
            {
                Id = s.Id,
                IdentificationNumber = s.IdentificationNumber,
                FirtsName = s.FirstName,
                LastName = s.LastName,
                Birthdate = s.Birthdate
            }).ToList();
        }
    }
}
