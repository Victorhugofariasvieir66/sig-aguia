
using SigAguia.Domain.Membros;

namespace SigAguia.Application.Membros.Repositories
{
    public interface IMembroRepository
    {
        Task<Membro?> BuscarPorPessoaIdAsync(
            Guid pessoaId,
            CancellationToken cancellationToken = default);

        Task<Membro?> BuscarPorIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task AdicionarAsync(
            Membro membro,
            CancellationToken cancellationToken = default);
    }
}
