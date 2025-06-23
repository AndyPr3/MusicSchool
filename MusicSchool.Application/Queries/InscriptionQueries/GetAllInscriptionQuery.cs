using MediatR;
using MusicSchool.Application.DTOs;

namespace MusicSchool.Application.Queries.InscriptionQueries
{
    public record GetAllInscriptionQuery() : IRequest<List<InscriptionDto>>;
    public record GetByIdInscriptionQuery(int id) : IRequest<InscriptionDto>;
    public record GetAllByTeacherQuery(int teacherId) : IRequest<List<StudentWithSchoolDto>>;
}
