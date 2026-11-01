
using SigAguia.Application.Membros.Repositories;
using SigAguia.Application.Pessoas.Repositories;
using SigAguia.Domain.Membros;

namespace SigAguia.Application.Membros.CriarMembro
{
    public class CriarMembroHandler
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMembroRepository _membroRepository;

        public CriarMembroHandler(
            IPessoaRepository pessoaRepository,
            IMembroRepository membroRepository)
        {
            _pessoaRepository = pessoaRepository;
            _membroRepository = membroRepository;
        }

        public async Task<Guid> ExecutarAsync(
            CriarMembroCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command.PessoaId == Guid.Empty)
            {
                throw new ArgumentException(
                    "O identificador da pessoa é obrigatório.");
            }

            var pessoa = await _pessoaRepository.BuscarPorIdAsync(
                command.PessoaId,
                cancellationToken);

            if (pessoa is null)
            {
                throw new ArgumentException(
                    "Pessoa não encontrada.");
            }

            var membroExistente =
                await _membroRepository.BuscarPorPessoaIdAsync(
                    command.PessoaId,
                    cancellationToken);

            if (membroExistente is not null)
            {
                throw new InvalidOperationException(
                    "Esta pessoa já possui cadastro de membro.");
            }

            var membro = new Membro
            {
                PessoaId = command.PessoaId,
                DataIngresso = command.DataIngresso
            };

            await _membroRepository.AdicionarAsync(
                membro,
                cancellationToken);

            return membro.Id;
        }
    }
}
