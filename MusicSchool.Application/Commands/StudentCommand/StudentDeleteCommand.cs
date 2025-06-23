using MediatR;

namespace MusicSchool.Application.Commands.StudentCommand
{
    public record StudentDeleteCommand(int id) : IRequest<int>;
}
