using MediatR;
using MusicSchool.Domain.Entities;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Commands.StudentCommand
{
    public class StudentCreateCommandHandler : IRequestHandler<StudentCreateComand, int>
    {
        private readonly IStudentRepository _StudentRepository;
        public StudentCreateCommandHandler(IStudentRepository StudentRepository)
        {
            _StudentRepository = StudentRepository;
        }

        public async Task<int> Handle(StudentCreateComand request, CancellationToken cancellationToken)
        {
            var entity = new Student()
            {
                IdentificationNumber = request.IdentificationNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Birthdate = request.Birthdate
            };
            return await _StudentRepository.AddAsync(entity);
        }
    }
}
