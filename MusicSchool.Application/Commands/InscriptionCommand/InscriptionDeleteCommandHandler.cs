using MediatR;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Commands.InscriptionCommand
{
    public class InscriptionDeleteCommandHandler : IRequestHandler<InscriptionDeleteCommand, int>
    {
        private readonly IInscriptionRepository _repo;
        public InscriptionDeleteCommandHandler(IInscriptionRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(InscriptionDeleteCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.id);
            if (existing is null)
                throw new($"Inscription not found with Id {request.id}");

            var result = await _repo.DeleteAsync(request.id);
            return result;
        }
    }
}
