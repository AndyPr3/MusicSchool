using MediatR;

namespace MusicSchool.Application.Commands.SchoolCommand
{
    public class SchoolUpdateComand : IRequest<int>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
