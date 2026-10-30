using SigAguia.Application.Pessoas.Repositories;

namespace SigAguia.Application.Pessoas.AtualizarPessoa
{
    public class AtualizarPessoaHandler
    {
        private readonly IPessoaRepository _pessoaRepository;

        public AtualizarPessoaHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<bool> ExecutarAsync(
            Guid id,
            AtualizarPessoaCommand command,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(command.NomeCompleto))
                throw new ArgumentException("O nome completo é obrigatório.");

            var pessoa = await _pessoaRepository.BuscarPorIdAsync(
                id,
                cancellationToken);

            if (pessoa is null)
                return false;

            pessoa.NomeCompleto = command.NomeCompleto.Trim();
            pessoa.DataNascimento = command.DataNascimento;
            pessoa.Telefone = command.Telefone;
            pessoa.Email = command.Email;
            pessoa.EstadoCivil = command.EstadoCivil;
            pessoa.AtualizadoEm = DateTimeOffset.UtcNow;

            await _pessoaRepository.AtualizarAsync(
                pessoa,
                cancellationToken);

            return true;
        }
    }
}