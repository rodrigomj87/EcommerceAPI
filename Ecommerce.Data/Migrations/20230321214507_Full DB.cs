using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    public partial class FullDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(30)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetodosPagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodosPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoVariacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoVariacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoVariacoes_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UnidadesFederacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sigla = table.Column<string>(type: "varchar(2)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesFederacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendaStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasProdutos",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProdutos", x => new { x.ProdutoId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_CategoriasProdutos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoriasProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProdutoVariacaoDetalhes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoVariacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Item = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoVariacaoDetalhes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoVariacaoDetalhes_ProdutoVariacoes_ProdutoVariacaoId",
                        column: x => x.ProdutoVariacaoId,
                        principalTable: "ProdutoVariacoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    UnidadeFederacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidades_UnidadesFederacao_UnidadeFederacaoId",
                        column: x => x.UnidadeFederacaoId,
                        principalTable: "UnidadesFederacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PedidosVenda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroPedido = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataPrevistaEntrega = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnderecoEntregaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetodoPagamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorProdutos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorFrete = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VendaStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosVenda_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidosVenda_Enderecos_EnderecoEntregaId",
                        column: x => x.EnderecoEntregaId,
                        principalTable: "Enderecos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidosVenda_MetodosPagamento_MetodoPagamentoId",
                        column: x => x.MetodoPagamentoId,
                        principalTable: "MetodosPagamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidosVenda_VendaStatus_VendaStatusId",
                        column: x => x.VendaStatusId,
                        principalTable: "VendaStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientesEnderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(50)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    CEP = table.Column<string>(type: "varchar(8)", nullable: false),
                    CidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeRecebedor = table.Column<string>(type: "varchar(100)", nullable: false),
                    EhEnderecoPadrao = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesEnderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientesEnderecos_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClientesEnderecos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PedidosVendaProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoVendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoVariacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosVendaProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosVendaProdutos_PedidosVenda_PedidoVendaId",
                        column: x => x.PedidoVendaId,
                        principalTable: "PedidosVenda",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidosVendaProdutos_ProdutoVariacoes_ProdutoVariacaoId",
                        column: x => x.ProdutoVariacaoId,
                        principalTable: "ProdutoVariacoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasProdutos_CategoriaId",
                table: "CategoriasProdutos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_UnidadeFederacaoId",
                table: "Cidades",
                column: "UnidadeFederacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesEnderecos_CidadeId",
                table: "ClientesEnderecos",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesEnderecos_ClienteId",
                table: "ClientesEnderecos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosVenda_ClienteId",
                table: "PedidosVenda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosVenda_EnderecoEntregaId",
                table: "PedidosVenda",
                column: "EnderecoEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosVenda_MetodoPagamentoId",
                table: "PedidosVenda",
                column: "MetodoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosVenda_VendaStatusId",
                table: "PedidosVenda",
                column: "VendaStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosVendaProdutos_PedidoVendaId",
                table: "PedidosVendaProdutos",
                column: "PedidoVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosVendaProdutos_ProdutoVariacaoId",
                table: "PedidosVendaProdutos",
                column: "ProdutoVariacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoVariacaoDetalhes_ProdutoVariacaoId",
                table: "ProdutoVariacaoDetalhes",
                column: "ProdutoVariacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoVariacoes_ProdutoId",
                table: "ProdutoVariacoes",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriasProdutos");

            migrationBuilder.DropTable(
                name: "ClientesEnderecos");

            migrationBuilder.DropTable(
                name: "PedidosVendaProdutos");

            migrationBuilder.DropTable(
                name: "ProdutoVariacaoDetalhes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "PedidosVenda");

            migrationBuilder.DropTable(
                name: "ProdutoVariacoes");

            migrationBuilder.DropTable(
                name: "UnidadesFederacao");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "MetodosPagamento");

            migrationBuilder.DropTable(
                name: "VendaStatus");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Produtos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
