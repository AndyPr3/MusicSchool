using MediatR;

namespace MusicSchool.Application.Commands.SchoolCommand
{
    public record SchoolDeleteCommand(int id) : IRequest<int>;
}
