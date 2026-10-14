using SigAguia.Application.Unidades.Repositories;
using SigAguia.Domain.Unidades;

namespace SigAguia.Application.Unidades.CriarUnidade
{
    public class CriarUnidadeHandler
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public CriarUnidadeHandler(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        public async Task<CriarUnidadeResult> ExecutarAsync(
            CriarUnidadeCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command.EhMatriz)
            {
                var existeMatriz = await _unidadeRepository.ExisteMatrizAsync(
                    cancellationToken);

                if (existeMatriz)
                {
                    throw new MatrizJaExisteException();
                }
            }

            var unidade = new Unidade
            {
                Nome = command.Nome.Trim(),
                EhMatriz = command.EhMatriz
            };

            await _unidadeRepository.AdicionarAsync(
                unidade,
                cancellationToken);

            return new CriarUnidadeResult
            {
                Id = unidade.Id,
                Nome = unidade.Nome,
                EhMatriz = unidade.EhMatriz
            };
        }
    }
}