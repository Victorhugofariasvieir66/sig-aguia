using SigAguia.Domain.Pessoas;

namespace SigAguia.Application.Pessoas.Repositories
{
    public interface IPessoaRepository
    {
        Task AdicionarAsync(
            Pessoa pessoa,
            CancellationToken cancellationToken = default);

        Task<Pessoa?> BuscarPorIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<List<Pessoa>> ListarAsync(
           CancellationToken cancellationToken = default);

        Task AtualizarAsync(
          Pessoa pessoa,
          CancellationToken cancellationToken = default);
    }
}