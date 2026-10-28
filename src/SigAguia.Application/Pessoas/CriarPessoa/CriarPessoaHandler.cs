using SigAguia.Domain.Pessoas;
using SigAguia.Application.Pessoas.Repositories;

namespace SigAguia.Application.Pessoas.CriarPessoa
{
    public class CriarPessoaHandler
    {
        private readonly IPessoaRepository _pessoaRepository;

        public CriarPessoaHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Guid> ExecutarAsync(
            CriarPessoaCommand command,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(command.NomeCompleto))
            {
                throw new ArgumentException(
                    "O nome completo é obrigatório.");
            }

            var pessoa = new Pessoa
            {
                NomeCompleto = command.NomeCompleto.Trim(),
                DataNascimento = command.DataNascimento,
                Telefone = command.Telefone,
                Email = command.Email,
                EstadoCivil = command.EstadoCivil
            };

            await _pessoaRepository.AdicionarAsync(
                pessoa,
                cancellationToken);

            return pessoa.Id;
        }
    }
}