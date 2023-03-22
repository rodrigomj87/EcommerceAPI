﻿using Ecommerce.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CategoriaProduto> CategoriasProdutos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteEndereco> ClientesEnderecos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<MetodoPagamento> MetodosPagamento { get; set; }
        public DbSet<PedidoVenda> PedidosVenda { get; set; }
        public DbSet<PedidoVendaProduto> PedidosVendaProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoVariacao> ProdutoVariacoes { get; set; }
        public DbSet<ProdutoVariacaoDetalhe> ProdutoVariacaoDetalhes { get; set; }
        public DbSet<UnidadeFederacao> UnidadesFederacao { get; set; }
        public DbSet<VendaStatus> VendaStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Se necessário configura tipo de coluna e tamanho padrão para não mapeados
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(decimal))))
                property.SetColumnType("decimal(18,2)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly);

            //Configura Delete Cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
