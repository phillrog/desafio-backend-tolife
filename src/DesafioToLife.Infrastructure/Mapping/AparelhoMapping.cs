using DesafioToLife.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioToLife.Infrastructure.Mapping
{
    public class AparelhoMapping : IEntityTypeConfiguration<Aparelho>
    {
        public void Configure(EntityTypeBuilder<Aparelho> builder)
        {
            builder.ToTable("Aparelhos");

            builder.HasKey(a => a.Id);

            builder.Property(a=> a.Name).IsRequired().HasMaxLength(120);

            builder.HasMany(a => a.Planos)
                   .WithOne()
                   .HasForeignKey(p => p.AparelhoId);
        }
    }
}
