using SigAguia.Application.Pessoas.Repositories;
using SigAguia.Domain.Pessoas;
using SigAguia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using SigAguia.Application.Pessoas.AtualizarPessoa;

namespace SigAguia.Infrastructure.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly SigAguiaDbContext _dbContext;

        public PessoaRepository(SigAguiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AdicionarAsync(
            Pessoa pessoa,
            CancellationToken cancellationToken = default)
        {
            await _dbContext.Pessoas.AddAsync(
                pessoa,
                cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<Pessoa?> BuscarPorIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Pessoas
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    pessoa => pessoa.Id == id,
                    cancellationToken);
        }
        public async Task<List<Pessoa>> ListarAsync(
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Pessoas
                .AsNoTracking()
                .OrderBy(pessoa => pessoa.NomeCompleto)
                .ToListAsync(cancellationToken);
        }
        public async Task AtualizarAsync(
           Pessoa pessoa,
           CancellationToken cancellationToken = default)
        {
            _dbContext.Pessoas.Update(pessoa);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}