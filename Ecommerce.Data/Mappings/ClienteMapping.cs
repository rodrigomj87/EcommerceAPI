using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .HasMaxLength(50)
                   .HasColumnType("varchar")
                   .IsRequired();

            builder.Property(c => c.Email)
                   .HasMaxLength(100)
                   .HasColumnType("varchar")
                   .IsRequired();

            builder.Property(c => c.DataCadastro)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.HasMany(c => c.PedidoVenda)
                   .WithOne(pv => pv.Cliente)
                   .HasForeignKey(pv => pv.ClienteId);

            builder.HasMany(c => c.ClienteEnderecos)
                   .WithOne(ce => ce.Cliente)
                   .HasForeignKey(ce => ce.ClienteId);
        }
    }

}
