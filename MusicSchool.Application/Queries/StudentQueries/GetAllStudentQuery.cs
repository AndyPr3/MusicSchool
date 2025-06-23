using MediatR;
using MusicSchool.Application.DTOs;

namespace MusicSchool.Application.Queries.StudentQueries
{
    public record GetAllStudentQuery() : IRequest<List<StudentDto>>;
    public record GetByIdStudentQuery(int id) : IRequest<StudentDto>;
}
