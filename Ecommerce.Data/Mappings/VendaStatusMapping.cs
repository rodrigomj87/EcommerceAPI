using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Mappings
{
    public class VendaStatusMapping : IEntityTypeConfiguration<VendaStatus>
    {
        public void Configure(EntityTypeBuilder<VendaStatus> builder)
        {
            builder.ToTable("VendaStatus");

            builder.HasKey(vs => vs.Id);

            builder.Property(vs => vs.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            builder.Property(vs => vs.Ativo)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnType("bit");
        }
    }
}
