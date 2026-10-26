using Microsoft.EntityFrameworkCore;
using SigAguia.Application.Unidades.Repositories;
using SigAguia.Domain.Unidades;
using SigAguia.Infrastructure.Persistence;

namespace SigAguia.Infrastructure.Repositories
{
    public class UnidadeRepository : IUnidadeRepository
    {
        private readonly SigAguiaDbContext _dbContext;

        public UnidadeRepository(SigAguiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExisteMatrizAsync(
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Unidades
                .AnyAsync(
                    unidade => unidade.EhMatriz,
                    cancellationToken);
        }

        public async Task AdicionarAsync(
            Unidade unidade,
            CancellationToken cancellationToken = default)
        {
            await _dbContext.Unidades.AddAsync(
                unidade,
                cancellationToken);
  
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
         
        public async Task<List<Unidade>> ListarAsync(
           CancellationToken cancellationToken = default)    
        {
           return await _dbContext.Unidades
              .AsNoTracking()
              .OrderBy(unidade => unidade.Nome)
              .ToListAsync(cancellationToken);
        }
        public async Task<Unidade?> BuscarPorIdAsync(
           Guid id,
           CancellationToken cancellationToken = default)
        {
           return await _dbContext.Unidades
           .AsNoTracking()
            .FirstOrDefaultAsync(
                  unidade => unidade.Id == id,
                  cancellationToken);
        }
        public async Task AtualizarAsync(
            Unidade unidade,
            CancellationToken cancellationToken = default)
       {
           _dbContext.Unidades.Update(unidade);

            await _dbContext.SaveChangesAsync(cancellationToken);
       }
    }
}