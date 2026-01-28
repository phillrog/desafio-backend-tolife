using DesafioToLife.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DesafioToLife.Infrastructure.Mapping
{
    public class PlanoMapping : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.ToTable("Planos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(60);
            builder.Property(p => p.Type).HasConversion<int>();
            builder.Property(p => p.PhonePrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PhonePriceOnPlan).HasColumnType("decimal(18,2)");
            builder.Property(p => p.MonthlyFee).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Installments);
            builder.Property(p => p.AparelhoId);

            builder.OwnsOne(p => p.Schedule, s => {
                s.Property(s => s.StartDate).HasColumnName("StartDateSchedule");
            });
            builder.OwnsOne(p => p.Localidade, l =>
            {
                l.Property(l => l.Nome).HasColumnName("NomeLocalidade");
                l.Property(l => l.Prioridade).HasColumnName("PrioridadeLocalidade");
            });
        }
    }
}
