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

            // Regra 2
            List<Aparelho> listaAparelhos = await _context.Aparelhos
                                      .AsNoTracking()
                                      .Include(a => a.Planos.Where(p => p.Schedule.StartDate > dataAtual))
                                      .Skip((page - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToListAsync();

            foreach (var aparelho in listaAparelhos)
            {
                var planosFiltrados = aparelho.Planos
                    // Regra 3
                    .OrderBy(p => p.Localidade.Prioridade)

                    // Regra 1
                    .GroupBy(p => new { p.Name, p.Type })

                    // Regra 4
                    .Select(g => g.First())
                    .ToList();

                aparelho.AdicionarPlano(planosFiltrados);
            }

            return listaAparelhos;
        }
    }
}
