using SigAguia.Application.Membros.Repositories;

namespace SigAguia.Application.Membros.EncerrarVinculoMembroUnidade
{
    public class EncerrarVinculoMembroUnidadeHandler
    {
        private readonly IMembroUnidadeRepository _repository;

        public EncerrarVinculoMembroUnidadeHandler(
            IMembroUnidadeRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecutarAsync(
            Guid vinculoId,
            DateOnly dataFim,
            CancellationToken cancellationToken = default)
        {
            if (vinculoId == Guid.Empty)
                throw new ArgumentException("O ID do vínculo é obrigatório.");

            if (dataFim == default)
                throw new ArgumentException("A data de encerramento é obrigatória.");

            var vinculo = await _repository.BuscarPorIdAsync(
                vinculoId, cancellationToken);

            if (vinculo is null)
                throw new KeyNotFoundException("Vínculo não encontrado.");

            if (vinculo.DataFim is not null)
                throw new InvalidOperationException(
                    "Este vínculo já está encerrado.");

            if (dataFim < vinculo.DataInicio)
                throw new ArgumentException(
                    "A data de encerramento não pode ser anterior à data de início.");

            vinculo.DataFim = dataFim;
            vinculo.AtualizadoEm = DateTimeOffset.UtcNow;

            await _repository.SalvarAlteracoesAsync(cancellationToken);
        }
    }
}