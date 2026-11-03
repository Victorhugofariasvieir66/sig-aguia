using SigAguia.Application.Membros.Repositories;
using SigAguia.Domain.Membros;

namespace SigAguia.Application.Membros.ListarMembros
{
    public class ListarMembrosHandler
    {
        private readonly IMembroRepository _membroRepository;

        public ListarMembrosHandler(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }

        public async Task<IEnumerable<Membro>> ExecutarAsync(
            CancellationToken cancellationToken = default)
        {
            return await _membroRepository.ListarAsync(cancellationToken);
        }
    }
}