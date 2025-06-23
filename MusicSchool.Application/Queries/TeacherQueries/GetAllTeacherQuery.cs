using MediatR;
using MusicSchool.Application.DTOs;

namespace MusicSchool.Application.Queries.TeacherQueries
{
    public record GetAllTeacherQuery() : IRequest<List<TeacherDto>>;
    public record GetByIdTeacherQuery(int id) : IRequest<TeacherDto>;
}
