using MediatR;

namespace MusicSchool.Application.Commands.TeacherCommand
{
    public record TeacherDeleteCommand(int id) : IRequest<int>;
}
