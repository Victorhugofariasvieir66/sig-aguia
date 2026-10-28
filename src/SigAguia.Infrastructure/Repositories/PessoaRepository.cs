using SigAguia.Application.Pessoas.Repositories;
using SigAguia.Domain.Pessoas;
using SigAguia.Infrastructure.Persistence;

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
    }
}