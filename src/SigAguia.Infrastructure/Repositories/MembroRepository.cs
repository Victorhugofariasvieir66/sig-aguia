
using Microsoft.EntityFrameworkCore;
using SigAguia.Application.Membros.Repositories;
using SigAguia.Domain.Membros;
using SigAguia.Infrastructure.Persistence;

namespace SigAguia.Infrastructure.Repositories
{
    public class MembroRepository : IMembroRepository
    {
        private readonly SigAguiaDbContext _dbContext;

        public MembroRepository(SigAguiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Membro?> BuscarPorPessoaIdAsync(
            Guid pessoaId,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Membros
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    m => m.PessoaId == pessoaId,
                    cancellationToken);
        }

        public async Task<Membro?> BuscarPorIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Membros
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    m => m.Id == id,
                    cancellationToken);
        }
        public async Task<IEnumerable<Membro>> ListarAsync(
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Membros
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        public async Task AdicionarAsync(
            Membro membro,
            CancellationToken cancellationToken = default)
        {
            await _dbContext.Membros.AddAsync(
                membro,
                cancellationToken);

            await _dbContext.SaveChangesAsync(
                cancellationToken);
        }
        public async Task AtualizarAsync(
             Membro membro,
             CancellationToken cancellationToken = default)
        {
            _dbContext.Membros.Attach(membro);

            var entrada = _dbContext.Entry(membro);

            entrada.Property(m => m.DataIngresso).IsModified = true;
            entrada.Property(m => m.AtualizadoEm).IsModified = true;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
