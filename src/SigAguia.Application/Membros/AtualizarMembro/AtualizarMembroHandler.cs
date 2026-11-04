using SigAguia.Application.Membros.Repositories;

namespace SigAguia.Application.Membros.AtualizarMembro
{
    public class AtualizarMembroHandler
    {
        private readonly IMembroRepository _membroRepository;

        public AtualizarMembroHandler(
            IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }

        public async Task<bool> ExecutarAsync(
            Guid id,
            AtualizarMembroCommand command,
            CancellationToken cancellationToken = default)
        {
            var membro = await _membroRepository.BuscarPorIdAsync(
                id,
                cancellationToken);

            if (membro is null)
            {
                return false;
            }

            membro.DataIngresso = command.DataIngresso;
            membro.AtualizadoEm = DateTimeOffset.UtcNow;

            await _membroRepository.AtualizarAsync(
                membro,
                cancellationToken);

            return true;
        }
    }
}