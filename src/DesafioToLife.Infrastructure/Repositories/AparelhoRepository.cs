using DesafioToLife.Domain.Entities;
using DesafioToLife.Domain.Intrerfaces;
using DesafioToLife.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioToLife.Infrastructure.Repositories
{
    public class AparelhoRepository : GenericRepository<Aparelho>, IAparelhoRepository
    {
        public AparelhoRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Aparelho>> ObterTodos(int page, int pageSize)
        {
            var dataAtual = DateTime.Now;
            return await _context.Aparelhos
                .AsNoTracking()
                .Include(a => a.Planos
                                    .Where(p => p.Schedule.StartDate > dataAtual)
                                    .OrderBy(p => p.Localidade.Prioridade)
                                )
                .Skip((page - 1) * pageSize)
                .Take(pageSize) 
                .ToListAsync();

        }
    }
}
