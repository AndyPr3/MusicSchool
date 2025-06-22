using MediatR;
using MusicSchool.Application.DTOs;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Queries.SchoolQueries
{
    public class GetByIdSchoolQueryHandler : IRequestHandler<GetByIdSchoolQuery, SchoolDto>
    {
        private readonly ISchoolRepository _repo;
        public GetByIdSchoolQueryHandler(ISchoolRepository repo)
            => _repo = repo;

        public async Task<SchoolDto> Handle(
            GetByIdSchoolQuery request,
            CancellationToken ct)
        {
            var school = await _repo.GetByIdAsync(request.id);
            if (school is null)
                throw new($"School not found with Id {request.id}");
            return new SchoolDto
            {
                Id = school.Id,
                Code = school.Code,
                Name = school.Name,
                Description = school.Description
            };
        }
    }
}
