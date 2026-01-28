using DesafioToLife.Domain.Entities;
using DesafioToLife.Domain.Enums;
using DesafioToLife.Domain.ValueObjects;
using DesafioToLife.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioToLife.Infrastructure.Seed
{
    public static class DBDesafioToLifeInitializer
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (context.Aparelhos.Any()) return;

            var aparelho = new Aparelho("Samsung Galaxy S8");

            var planos = new List<Plano>
            {
                new (1, "Plano Básico 5GB", TipoPlanoEnum.Pos, 2899, 2229, 12, 100, new Schedule(DateTime.Parse("2026-12-06")), new Localidade("MINAS GERAIS", 2)),
                new (2, "Plano Básico 5GB", TipoPlanoEnum.Pos, 2899, 2199, 12, 99, new Schedule(DateTime.Parse("2026-12-06")), new Localidade("BRASIL", 1)),
                new (3, "Plano Básico 5GB", TipoPlanoEnum.Pos, 2899, 2199, 12, 99, new Schedule(DateTime.Parse("2026-12-06")), new Localidade("BRASIL", 1)),
                new (10, "Plano Intermediário 20GB", TipoPlanoEnum.Pos, 3000, 2500, 12, 150, new Schedule(DateTime.Parse("2026-12-06")), new Localidade("BRASIL", 1)),
                new (11, "Plano Intermediário 20GB", TipoPlanoEnum.Pos, 3000, 2600, 12, 160, new Schedule(DateTime.Parse("2026-12-06")), new Localidade("SAO PAULO", 2)),
                new (12, "Plano Intermediário 20GB", TipoPlanoEnum.Pos, 3000, 2700, 12, 170, new Schedule(DateTime.Parse("2025-11-07")), new Localidade("BELO HORIZONTE", 3)),
                new (20, "Plano Premium 100GB", TipoPlanoEnum.Pos, 4000, 3000, 12, 299, new Schedule(DateTime.Parse("2025-07-29")), new Localidade("BRASIL", 1)),
                new (21, "Plano Premium 100GB", TipoPlanoEnum.Pos, 4000, 3100, 12, 309, new Schedule(DateTime.Parse("2025-11-06")), new Localidade("SAO PAULO", 2)),
                new (30, "Plano Controle 10GB", TipoPlanoEnum.Controle, 2500, 2000, 12, 49.99m, new Schedule(DateTime.Parse("2025-07-29")), new Localidade("BRASIL", 1)),
                new (31, "Plano Controle 10GB", TipoPlanoEnum.Controle, 2500, 2100, 12, 59.99m, new Schedule(DateTime.Parse("2025-11-07")), new Localidade("SAO PAULO", 2)),
                new (32, "Plano Controle 10GB", TipoPlanoEnum.Controle, 2500, 2150, 12, 64.99m, new Schedule(DateTime.Parse("2026-12-06")), new Localidade("RIO DE JANEIRO", 2)),
                new (40, "Plano Easy 2GB", TipoPlanoEnum.Controle, 2000, 1800, 12, 39.99m, new Schedule(DateTime.Parse("2026-12-06")), new Localidade("BELO HORIZONTE", 3))
            };

            foreach (var plano in planos)
            {
                aparelho.AdicionarPlano(plano);
            }

            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await context.Database.BeginTransactionAsync();
                try
                {
                    await context.Database.OpenConnectionAsync();

                    // Habilita a inserção manual de IDs para a tabela Planos
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Planos ON");

                    context.Aparelhos.Add(aparelho);

                    await context.SaveChangesAsync();

                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Planos OFF");
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                finally
                {
                    await context.Database.CloseConnectionAsync();
                }
            });
        }
    }
}
