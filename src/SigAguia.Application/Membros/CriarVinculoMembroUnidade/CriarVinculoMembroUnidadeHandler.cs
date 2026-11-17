using SigAguia.Application.Membros.Repositories;
using SigAguia.Application.Unidades.Repositories;
using SigAguia.Domain.Membros;

namespace SigAguia.Application.Membros.CriarVinculoMembroUnidade
{
    public class CriarVinculoMembroUnidadeHandler
    {
        private readonly IMembroRepository _membroRepository;
        private readonly IUnidadeRepository _unidadeRepository;
        private readonly IMembroUnidadeRepository _membroUnidadeRepository;

        public CriarVinculoMembroUnidadeHandler(
            IMembroRepository membroRepository,
            IUnidadeRepository unidadeRepository,
            IMembroUnidadeRepository membroUnidadeRepository)
        {
            _membroRepository = membroRepository;
            _unidadeRepository = unidadeRepository;
            _membroUnidadeRepository = membroUnidadeRepository;
        }

        public async Task<Guid> ExecutarAsync(
            Guid membroId,
            CriarVinculoMembroUnidadeCommand command,
            CancellationToken cancellationToken = default)
        {
            if (membroId == Guid.Empty)
            {
                throw new ArgumentException(
                    "O identificador do membro é obrigatório.");
            }

            if (command.UnidadeId == Guid.Empty)
            {
                throw new ArgumentException(
                    "O identificador da unidade é obrigatório.");
            }

            if (command.DataInicio == default)
            {
                throw new ArgumentException(
                    "A data de início é obrigatória.");
            }

            if (command.TipoVinculo != "Principal")
            {
                throw new ArgumentException(
                    "Por enquanto, apenas o vínculo Principal é permitido.");
            }

            var membro = await _membroRepository.BuscarPorIdAsync(
                membroId,
                cancellationToken);

            if (membro is null)
            {
                throw new KeyNotFoundException(
                    "Membro não encontrado.");
            }

            var unidade = await _unidadeRepository.BuscarPorIdAsync(
                command.UnidadeId,
                cancellationToken);

            if (unidade is null)
            {
                throw new KeyNotFoundException(
                    "Unidade não encontrada.");
            }

            var vinculoExistente =
                await _membroUnidadeRepository.BuscarVinculoPrincipalAtivoAsync(
                    membroId,
                    cancellationToken);

            if (vinculoExistente is not null)
            {
                throw new InvalidOperationException(
                    "O membro já possui um vínculo principal ativo.");
            }

            var vinculo = new MembroUnidade
            {
                MembroId = membroId,
                UnidadeId = command.UnidadeId,
                TipoVinculo = "Principal",
                DataInicio = command.DataInicio
            };

            await _membroUnidadeRepository.AdicionarAsync(
                vinculo,
                cancellationToken);

            return vinculo.Id;
        }
    }
}