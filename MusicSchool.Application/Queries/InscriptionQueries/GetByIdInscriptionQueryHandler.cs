using MediatR;
using MusicSchool.Application.DTOs;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Queries.InscriptionQueries
{
    public class GetByIdInscriptionQueryHandler : IRequestHandler<GetByIdInscriptionQuery, InscriptionDto>
    {
        private readonly IInscriptionRepository _repo;
        public GetByIdInscriptionQueryHandler(IInscriptionRepository repo)
            => _repo = repo;

        public async Task<InscriptionDto> Handle(
            GetByIdInscriptionQuery request,
            CancellationToken ct)
        {
            var inscription = await _repo.GetByIdAsync(request.id);
            if (inscription is null)
                throw new($"Inscription not found with Id {request.id}");

            return new InscriptionDto
            {
                Id = inscription.Id,
                Student = new StudentDto
                {
                    Id = inscription.Student.Id,
                    FirtsName = inscription.Student.FirstName,
                    LastName = inscription.Student.LastName
                },
                Teacher = new TeacherDto
                {
                    Id = inscription.Teacher.Id,
                    FirtsName = inscription.Teacher.FirstName,
                    LastName = inscription.Teacher.LastName
                },
                AssignedAt = inscription.AssignedAt
            };
        }
    }
}
