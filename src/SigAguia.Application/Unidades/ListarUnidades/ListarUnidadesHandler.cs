using SigAguia.Application.Unidades.Repositories;

namespace SigAguia.Application.Unidades.ListarUnidades
{
    public class ListarUnidadesHandler
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public ListarUnidadesHandler(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        public async Task<List<ListarUnidadesResult>> ExecutarAsync(
            CancellationToken cancellationToken = default)
        {
            var unidades = await _unidadeRepository.ListarAsync(
                cancellationToken);

            return unidades
                .Select(unidade => new ListarUnidadesResult
                {
                    Id = unidade.Id,
                    Nome = unidade.Nome,
                    EhMatriz = unidade.EhMatriz,
                    Ativa = unidade.Ativa
                })
                .ToList();
        }
    }
}