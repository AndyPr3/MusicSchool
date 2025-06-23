using MediatR;
using MusicSchool.Application.DTOs;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Queries.TeacherQueries
{
    public class GetAllTeacherQueryHandler : IRequestHandler<GetAllTeacherQuery, List<TeacherDto>>
    {
        private readonly ITeacherRepository _repo;
        public GetAllTeacherQueryHandler(ITeacherRepository repo)
            => _repo = repo;

        public async Task<List<TeacherDto>> Handle(
            GetAllTeacherQuery request,
            CancellationToken ct)
        {
            var schools = await _repo.GetAllAsync();
            return schools.Select(s => new TeacherDto
            {
                Id = s.Id,
                IdentificationNumber = s.IdentificationNumber,
                FirtsName = s.FirstName,
                LastName = s.LastName
            }).ToList();
        }
    }
}
