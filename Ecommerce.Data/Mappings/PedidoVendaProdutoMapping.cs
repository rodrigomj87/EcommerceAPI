using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Mappings
{
    public class PedidoVendaProdutoMapping : IEntityTypeConfiguration<PedidoVendaProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoVendaProduto> builder)
        {
            builder.ToTable("PedidosVendaProdutos");

            // Chave primária
            builder.HasKey(pvp => pvp.Id);

            builder.Property(pvp => pvp.Quantidade)
                   .IsRequired();

            builder.Property(pvp => pvp.Valor)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.HasOne(pvp => pvp.PedidoVenda)
                   .WithMany(pv => pv.PedidoVendaProdutos)
                   .HasForeignKey(pvp => pvp.PedidoVendaId);

            builder.HasOne(pvp => pvp.ProdutoVariacao)
                   .WithMany()
                   .HasForeignKey(pvp => pvp.ProdutoVariacaoId);
        }
    }
}
