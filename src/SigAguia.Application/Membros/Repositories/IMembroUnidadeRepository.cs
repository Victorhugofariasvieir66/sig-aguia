using SigAguia.Domain.Membros;

namespace SigAguia.Application.Membros.Repositories
{
    public interface IMembroUnidadeRepository
    {
        Task AdicionarAsync(
            MembroUnidade membroUnidade,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<MembroUnidade>> ListarPorMembroIdAsync(
            Guid membroId,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<MembroUnidade>> ListarPorUnidadeIdAsync(
            Guid unidadeId,
            CancellationToken cancellationToken = default);

        Task<MembroUnidade?> BuscarVinculoPrincipalAtivoAsync(
            Guid membroId,
            CancellationToken cancellationToken = default);
    }
}