using MediatR;
using MusicSchool.Application.DTOs;
using MusicSchool.Application.Inferfaces;

namespace MusicSchool.Application.Queries.InscriptionQueries
{
    public class GetAllByTeacherQueryHandler : IRequestHandler<GetAllByTeacherQuery, List<StudentWithSchoolDto>>
    {
        private readonly IInscriptionQueries _repo;
        public GetAllByTeacherQueryHandler(IInscriptionQueries repo)
            => _repo = repo;

        public async Task<List<StudentWithSchoolDto>> Handle(
            GetAllByTeacherQuery request,
            CancellationToken ct)
        {
            var data = await _repo.GetStudentsByTeacherAsync(request.teacherId);
            return data;
        }
    }
}
