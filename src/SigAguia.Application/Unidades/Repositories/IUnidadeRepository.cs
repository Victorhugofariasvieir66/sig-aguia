using SigAguia.Domain.Unidades;

namespace SigAguia.Application.Unidades.Repositories
{
    public interface IUnidadeRepository
    {
        Task<bool> ExisteMatrizAsync(
            CancellationToken cancellationToken = default);

        Task AdicionarAsync(
            Unidade unidade,
            CancellationToken cancellationToken = default);
    }
}