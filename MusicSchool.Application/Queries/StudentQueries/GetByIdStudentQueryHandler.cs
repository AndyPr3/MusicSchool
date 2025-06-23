using MediatR;
using MusicSchool.Application.DTOs;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Queries.StudentQueries
{
    public class GetByIdStudentQueryHandler : IRequestHandler<GetByIdStudentQuery, StudentDto>
    {
        private readonly IStudentRepository _repo;
        public GetByIdStudentQueryHandler(IStudentRepository repo)
            => _repo = repo;

        public async Task<StudentDto> Handle(
            GetByIdStudentQuery request,
            CancellationToken ct)
        {
            var student = await _repo.GetByIdAsync(request.id);
            if (student is null)
                throw new($"Student not found with Id {request.id}");
            return new StudentDto
            {
                Id = student.Id,
                IdentificationNumber = student.IdentificationNumber,
                FirtsName = student.FirstName,
                LastName = student.LastName,
                Birthdate = student.Birthdate,
            };
        }
    }
}
