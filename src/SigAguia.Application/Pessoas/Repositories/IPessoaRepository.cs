using SigAguia.Domain.Pessoas;

namespace SigAguia.Application.Pessoas.Repositories
{
    public interface IPessoaRepository
    {
        Task AdicionarAsync(
            Pessoa pessoa,
            CancellationToken cancellationToken = default);
    }
}