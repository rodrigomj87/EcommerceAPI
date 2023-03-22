using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    public partial class PedidoVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosVenda_Enderecos_EnderecoEntregaId",
                table: "PedidosVenda");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosVenda_ClientesEnderecos_EnderecoEntregaId",
                table: "PedidosVenda",
                column: "EnderecoEntregaId",
                principalTable: "ClientesEnderecos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosVenda_ClientesEnderecos_EnderecoEntregaId",
                table: "PedidosVenda");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosVenda_Enderecos_EnderecoEntregaId",
                table: "PedidosVenda",
                column: "EnderecoEntregaId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }
    }
}
