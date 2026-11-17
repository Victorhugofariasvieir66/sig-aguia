using SigAguia.Application.Membros.Repositories;
using SigAguia.Domain.Membros;

namespace SigAguia.Application.Membros.ListarVinculosMembro
{
    public class ListarVinculosMembroHandler
    {
        private readonly IMembroUnidadeRepository _membroUnidadeRepository;

        public ListarVinculosMembroHandler(
            IMembroUnidadeRepository membroUnidadeRepository)
        {
            _membroUnidadeRepository = membroUnidadeRepository;
        }

        public async Task<IEnumerable<MembroUnidade>> ExecutarAsync(
            Guid membroId,
            CancellationToken cancellationToken = default)
        {
            return await _membroUnidadeRepository
                .ListarPorMembroIdAsync(membroId, cancellationToken);
        }
    }
}