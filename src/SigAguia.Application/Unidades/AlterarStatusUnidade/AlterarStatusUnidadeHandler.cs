using SigAguia.Application.Unidades.Repositories;

namespace SigAguia.Application.Unidades.AlterarStatusUnidade
{
    public class AlterarStatusUnidadeHandler
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public AlterarStatusUnidadeHandler(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }
        public async Task<bool> ExecutarAsync(
             Guid id,
             AlterarStatusUnidadeCommand command,
             CancellationToken cancellationToken = default)
        {
            var unidade = await _unidadeRepository.BuscarPorIdAsync(
                id,
                cancellationToken);

            if (unidade is null)
            {
                return false;
            }

            unidade.Ativa = command.Ativa;
            unidade.AtualizadoEm = DateTimeOffset.UtcNow;

            await _unidadeRepository.AtualizarAsync(
                unidade,
                cancellationToken);

            return true;
        }
    }
}