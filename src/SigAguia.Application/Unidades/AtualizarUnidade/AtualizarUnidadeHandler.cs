using SigAguia.Application.Unidades.CriarUnidade;
using SigAguia.Application.Unidades.Repositories;

namespace SigAguia.Application.Unidades.AtualizarUnidade
{
    public class AtualizarUnidadeHandler
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public AtualizarUnidadeHandler(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }
        public async Task<bool> ExecutarAsync(
            Guid id,
            AtualizarUnidadeCommand command,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(command.Nome))
            {
                throw new NomeUnidadeInvalidoException();
            }

            var unidade = await _unidadeRepository.BuscarPorIdAsync(
                id,
                cancellationToken);

            if (unidade is null)
            {
                return false;
            }

            unidade.Nome = command.Nome.Trim();
            unidade.AtualizadoEm = DateTimeOffset.UtcNow;

            await _unidadeRepository.AtualizarAsync(
                unidade,
                cancellationToken);

            return true;
        }
    }
}