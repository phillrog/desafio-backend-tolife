using DesafioToLife.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DesafioToLife.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Aparelho> Aparelhos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
