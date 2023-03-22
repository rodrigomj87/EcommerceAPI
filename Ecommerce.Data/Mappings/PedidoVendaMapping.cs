using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Mappings
{
    public class PedidoVendaMapping : IEntityTypeConfiguration<PedidoVenda>
    {
        public void Configure(EntityTypeBuilder<PedidoVenda> builder)
        {
            builder.ToTable("PedidosVenda");

            builder.HasKey(pv => pv.Id);

            builder.Property(pv => pv.NumeroPedido)
                   .HasMaxLength(20)
                   .HasColumnType("varchar")
                   .IsRequired();

            builder.Property(pv => pv.DataPedido)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(pv => pv.DataPrevistaEntrega)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(pv => pv.ValorProdutos)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(pv => pv.ValorFrete)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.HasOne(pv => pv.Cliente)
                   .WithMany(c => c.PedidoVenda)
                   .HasForeignKey(pv => pv.ClienteId);

            builder.HasOne(pv => pv.EnderecoEntrega)
                   .WithMany()
                   .HasForeignKey(pv => pv.EnderecoEntregaId);

            builder.HasOne(pv => pv.MetodoPagamento)
                   .WithMany()
                   .HasForeignKey(pv => pv.MetodoPagamentoId);

            builder.HasOne(pv => pv.VendaStatus)
                   .WithMany()
                   .HasForeignKey(pv => pv.VendaStatusId);
        }
    }
}
