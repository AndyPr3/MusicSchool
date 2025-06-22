using MediatR;

namespace MusicSchool.Application.Commands.SchoolCommand
{
    public class SchoolCreateComand : IRequest<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
