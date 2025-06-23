using MediatR;

namespace MusicSchool.Application.Commands.InscriptionCommand
{
    public record InscriptionDeleteCommand(int id) : IRequest<int>;
}
