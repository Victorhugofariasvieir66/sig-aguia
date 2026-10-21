using SigAguia.Application.Unidades.Repositories;

namespace SigAguia.Application.Unidades.BuscarUnidadePorId
{
    public class BuscarUnidadePorIdHandler
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public BuscarUnidadePorIdHandler(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        public async Task<BuscarUnidadePorIdResult?> ExecutarAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            var unidade = await _unidadeRepository.BuscarPorIdAsync(
                id,
                cancellationToken);

            if (unidade is null)
            {
                return null;
            }

            return new BuscarUnidadePorIdResult
            {
                Id = unidade.Id,
                Nome = unidade.Nome,
                EhMatriz = unidade.EhMatriz,
                Ativa = unidade.Ativa
            };
        }
    }
}