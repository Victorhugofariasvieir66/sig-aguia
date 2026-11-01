
using SigAguia.Application.Membros.Repositories;
using SigAguia.Domain.Membros;

namespace SigAguia.Application.Membros.BuscarMembroPorId
{
    public class BuscarMembroPorIdHandler
    {
        private readonly IMembroRepository _membroRepository;

        public BuscarMembroPorIdHandler(
            IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }

        public async Task<Membro?> ExecutarAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _membroRepository.BuscarPorIdAsync(
                id,
                cancellationToken);
        }
    }
}
