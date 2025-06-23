using MediatR;

namespace MusicSchool.Application.Commands.InscriptionCommand
{
    public class InscriptionCreateComand : IRequest<int>
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }
}
