using MediatR;
using MusicSchool.Application.DTOs;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Queries.TeacherQueries
{
    public class GetByIdTeacherQueryHandler : IRequestHandler<GetByIdTeacherQuery, TeacherDto>
    {
        private readonly ITeacherRepository _repo;
        public GetByIdTeacherQueryHandler(ITeacherRepository repo)
            => _repo = repo;

        public async Task<TeacherDto> Handle(
            GetByIdTeacherQuery request,
            CancellationToken ct)
        {
            var Teacher = await _repo.GetByIdAsync(request.id);
            if (Teacher is null)
                throw new($"Teacher not found with Id {request.id}");
            return new TeacherDto
            {
                Id = Teacher.Id,
                IdentificationNumber = Teacher.IdentificationNumber,
                FirtsName = Teacher.FirstName,
                LastName = Teacher.LastName
            };
        }
    }
}
