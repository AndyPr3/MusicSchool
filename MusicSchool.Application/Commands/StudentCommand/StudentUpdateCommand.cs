using MediatR;

namespace MusicSchool.Application.Commands.StudentCommand
{
    public class StudentUpdateComand : IRequest<int>
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
