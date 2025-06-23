using MediatR;
using MusicSchool.Domain.Entities;
using MusicSchool.Domain.Interfaces;

namespace MusicSchool.Application.Commands.InscriptionCommand
{
    public class InscriptionCreateCommandHandler : IRequestHandler<InscriptionCreateComand, int>
    {
        private readonly IInscriptionRepository _InscriptionRepository;
        public InscriptionCreateCommandHandler(IInscriptionRepository InscriptionRepository)
        {
            _InscriptionRepository = InscriptionRepository;
        }

        public async Task<int> Handle(InscriptionCreateComand request, CancellationToken cancellationToken)
        {
            var entity = new Inscription()
            {
                StudentId = request.StudentId,
                TeacherId = request.TeacherId
            };
            return await _InscriptionRepository.AddAsync(entity);
        }
    }
}
