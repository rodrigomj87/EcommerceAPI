﻿// <auto-generated />
using System;
using Ecommerce.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20230322033613_ClienteTelefone")]
    partial class ClienteTelefone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ecommerce.Business.Models.Carrinho", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ClienteId");

                    b.Property<bool>("GerouPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("GerouPedido");

                    b.Property<int>("Parcelas")
                        .HasColumnType("int")
                        .HasColumnName("Parcelas");

                    b.Property<Guid>("ProdutoVariacaoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProdutoVariacaoId");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoVariacaoId");

                    b.ToTable("Carrinhos", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Ativo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Ativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.CategoriaProduto", b =>
                {
                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProdutoId", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("CategoriasProdutos", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Cidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("UnidadeFederacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UnidadeFederacaoId");

                    b.ToTable("Cidades", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.ClienteEndereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<Guid>("CidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("EhEnderecoPadrao")
                        .HasColumnType("bit");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NomeRecebedor")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("ClienteId");

                    b.ToTable("ClientesEnderecos", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId")
                        .IsUnique();

                    b.ToTable("Enderecos", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("TipoFornecedor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.MetodoPagamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Ativo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MetodosPagamento", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.PedidoVenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataPrevistaEntrega")
                        .HasColumnType("datetime");

                    b.Property<Guid>("EnderecoEntregaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MetodoPagamentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NumeroPedido")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("ValorFrete")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorProdutos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("VendaStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EnderecoEntregaId");

                    b.HasIndex("MetodoPagamentoId");

                    b.HasIndex("VendaStatusId");

                    b.ToTable("PedidosVenda", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.PedidoVendaProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PedidoVendaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProdutoVariacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoVendaId");

                    b.HasIndex("ProdutoVariacaoId");

                    b.ToTable("PedidosVendaProdutos", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.ProdutoVariacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoVariacoes", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.ProdutoVariacaoDetalhe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ProdutoVariacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoVariacaoId");

                    b.ToTable("ProdutoVariacaoDetalhes", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.UnidadeFederacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("UnidadesFederacao", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.VendaStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Ativo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("VendaStatus", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Carrinho", b =>
                {
                    b.HasOne("Ecommerce.Business.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .IsRequired();

                    b.HasOne("Ecommerce.Business.Models.ProdutoVariacao", "ProdutoVariacao")
                        .WithMany()
                        .HasForeignKey("ProdutoVariacaoId")
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("ProdutoVariacao");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.CategoriaProduto", b =>
                {
                    b.HasOne("Ecommerce.Business.Models.Categoria", "Categoria")
                        .WithMany("CategoriaProduto")
                        .HasForeignKey("CategoriaId")
                        .IsRequired();

                    b.HasOne("Ecommerce.Business.Models.Produto", "Produto")
                        .WithMany("CategoriaProduto")
                        .HasForeignKey("ProdutoId")
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Cidade", b =>
                {
                    b.HasOne("Ecommerce.Business.Models.UnidadeFederacao", "UnidadeFederacao")
                        .WithMany()
                        .HasForeignKey("UnidadeFederacaoId")
                        .IsRequired();

                    b.Navigation("UnidadeFederacao");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.ClienteEndereco", b =>
                {
                    b.HasOne("Ecommerce.Business.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .IsRequired();

                    b.HasOne("Ecommerce.Business.Models.Cliente", "Cliente")
                        .WithMany("ClienteEnderecos")
                        .HasForeignKey("ClienteId")
                        .IsRequired();

                    b.Navigation("Cidade");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Endereco", b =>
                {
                    b.HasOne("Ecommerce.Business.Models.Fornecedor", "Fornecedor")
                        .WithOne("Endereco")
                        .HasForeignKey("Ecommerce.Business.Models.Endereco", "FornecedorId")
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.PedidoVenda", b =>
                {
                    b.HasOne("Ecommerce.Business.Models.Cliente", "Cliente")
                        .WithMany("PedidoVenda")
                        .HasForeignKey("ClienteId")
                        .IsRequired();

                    b.HasOne("Ecommerce.Business.Models.ClienteEndereco", "EnderecoEntrega")
                        .WithMany()
                        .HasForeignKey("EnderecoEntregaId")
                        .IsRequired();

                    b.HasOne("Ecommerce.Business.Models.MetodoPagamento", "MetodoPagamento")
                        .WithMany()
                        .HasForeignKey("MetodoPagamentoId")
                        .IsRequired();

                    b.HasOne("Ecommerce.Business.Models.VendaStatus", "VendaStatus")
                        .WithMany()
                        .HasForeignKey("VendaStatusId")
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("EnderecoEntrega");

                    b.Navigation("MetodoPagamento");

                    b.Navigation("VendaStatus");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.PedidoVendaProduto", b =>
                {
                    b.HasOne("Ecommerce.Business.Models.PedidoVenda", "PedidoVenda")
                        .WithMany("PedidoVendaProdutos")
                        .HasForeignKey("PedidoVendaId")
                        .IsRequired();

                    b.HasOne("Ecommerce.Business.Models.ProdutoVariacao", "ProdutoVariacao")
                        .WithMany()
                        .HasForeignKey("ProdutoVariacaoId")
                        .IsRequired();

                    b.Navigation("PedidoVenda");

                    b.Navigation("ProdutoVariacao");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Produto", b =>
                {
                    b.HasOne("Ecommerce.Business.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId")
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.ProdutoVariacao", b =>
                {
                    b.HasOne("Ecommerce.Business.Models.Produto", "Produto")
                        .WithMany("ProdutoVariacoes")
                        .HasForeignKey("ProdutoId")
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.ProdutoVariacaoDetalhe", b =>
                {
                    b.HasOne("Ecommerce.Business.Models.ProdutoVariacao", "ProdutoVariacao")
                        .WithMany("ProdutoVariacaoDetalhe")
                        .HasForeignKey("ProdutoVariacaoId")
                        .IsRequired();

                    b.Navigation("ProdutoVariacao");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Categoria", b =>
                {
                    b.Navigation("CategoriaProduto");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Cliente", b =>
                {
                    b.Navigation("ClienteEnderecos");

                    b.Navigation("PedidoVenda");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Fornecedor", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.PedidoVenda", b =>
                {
                    b.Navigation("PedidoVendaProdutos");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.Produto", b =>
                {
                    b.Navigation("CategoriaProduto");

                    b.Navigation("ProdutoVariacoes");
                });

            modelBuilder.Entity("Ecommerce.Business.Models.ProdutoVariacao", b =>
                {
                    b.Navigation("ProdutoVariacaoDetalhe");
                });
#pragma warning restore 612, 618
        }
    }
}