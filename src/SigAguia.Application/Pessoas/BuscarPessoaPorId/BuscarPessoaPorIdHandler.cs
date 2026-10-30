using SigAguia.Application.Pessoas.Repositories;
using SigAguia.Domain.Pessoas;

namespace SigAguia.Application.Pessoas.BuscarPessoaPorId
{
    public class BuscarPessoaPorIdHandler
    {
        private readonly IPessoaRepository _pessoaRepository;

        public BuscarPessoaPorIdHandler(
            IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Pessoa?> ExecutarAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _pessoaRepository.BuscarPorIdAsync(
                id,
                cancellationToken);
        }
    }
}