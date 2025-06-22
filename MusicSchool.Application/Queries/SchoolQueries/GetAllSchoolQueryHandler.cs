using MediatR;
using MusicSchool.Application.DTOs;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Queries.SchoolQueries
{
    public class GetAllSchoolQueryHandler : IRequestHandler<GetAllSchoolQuery, List<SchoolDto>>
    {
        private readonly ISchoolRepository _repo;
        public GetAllSchoolQueryHandler(ISchoolRepository repo)
            => _repo = repo;

        public async Task<List<SchoolDto>> Handle(
            GetAllSchoolQuery request,
            CancellationToken ct)
        {
            var schools = await _repo.GetAllAsync();
            return schools.Select(s => new SchoolDto
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Description = s.Description
            }).ToList();
        }
    }
}
