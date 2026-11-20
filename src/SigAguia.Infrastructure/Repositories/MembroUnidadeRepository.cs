using Microsoft.EntityFrameworkCore;
using SigAguia.Application.Membros.Repositories;
using SigAguia.Domain.Membros;
using SigAguia.Infrastructure.Persistence;

namespace SigAguia.Infrastructure.Repositories
{
    public class MembroUnidadeRepository : IMembroUnidadeRepository
    {
        private readonly SigAguiaDbContext _dbContext;

        public MembroUnidadeRepository(SigAguiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AdicionarAsync(
            MembroUnidade membroUnidade,
            CancellationToken cancellationToken = default)
        {
            await _dbContext.MembrosUnidades.AddAsync(
                membroUnidade,
                cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<MembroUnidade>> ListarPorMembroIdAsync(
            Guid membroId,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.MembrosUnidades
                .AsNoTracking()
                .Where(mu => mu.MembroId == membroId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<MembroUnidade>> ListarPorUnidadeIdAsync(
            Guid unidadeId,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.MembrosUnidades
                .AsNoTracking()
                .Where(mu => mu.UnidadeId == unidadeId)
                .ToListAsync(cancellationToken);
        }

        public async Task<MembroUnidade?> BuscarVinculoPrincipalAtivoAsync(
            Guid membroId,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.MembrosUnidades
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    mu => mu.MembroId == membroId
                        && mu.DataFim == null
                        && mu.TipoVinculo == "Principal",
                    cancellationToken);
        }

        public async Task<MembroUnidade?> BuscarPorIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.MembrosUnidades
                .FirstOrDefaultAsync(mu => mu.Id == id, cancellationToken);
        }

        public async Task SalvarAlteracoesAsync(
            CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}