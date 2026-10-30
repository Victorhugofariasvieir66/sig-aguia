using SigAguia.Application.Pessoas.Repositories;
using SigAguia.Domain.Pessoas;

namespace SigAguia.Application.Pessoas.ListarPessoas
{
    public class ListarPessoasHandler
    {
        private readonly IPessoaRepository _pessoaRepository;

        public ListarPessoasHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<List<Pessoa>> ExecutarAsync(
            CancellationToken cancellationToken = default)
        {
            return await _pessoaRepository.ListarAsync(cancellationToken);
        }
    }
}