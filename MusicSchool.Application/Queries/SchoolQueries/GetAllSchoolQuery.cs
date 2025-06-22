using MediatR;
using MusicSchool.Application.DTOs;

namespace MusicSchool.Application.Queries.SchoolQueries
{
    public record GetAllSchoolQuery() : IRequest<List<SchoolDto>>;
    public record GetByIdSchoolQuery(int id) : IRequest<SchoolDto>;
}
