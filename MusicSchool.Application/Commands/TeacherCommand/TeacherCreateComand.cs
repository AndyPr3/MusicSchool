using MediatR;

namespace MusicSchool.Application.Commands.TeacherCommand
{
    public class TeacherCreateComand : IRequest<int>
    {
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SchoolId { get; set; }
    }
}
