using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercadorias.Infra.Repository.Migrations
{
    public partial class ckelw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Mercadoria_IdEntrada",
                table: "Entrada");

            migrationBuilder.DropForeignKey(
                name: "FK_Saida_Mercadoria_IdSaida",
                table: "Saida");

            migrationBuilder.CreateIndex(
                name: "IX_Saida_IdMercadoria",
                table: "Saida",
                column: "IdMercadoria");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_IdMercadoria",
                table: "Entrada",
                column: "IdMercadoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Mercadoria_IdMercadoria",
                table: "Entrada",
                column: "IdMercadoria",
                principalTable: "Mercadoria",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Saida_Mercadoria_IdMercadoria",
                table: "Saida",
                column: "IdMercadoria",
                principalTable: "Mercadoria",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Mercadoria_IdMercadoria",
                table: "Entrada");

            migrationBuilder.DropForeignKey(
                name: "FK_Saida_Mercadoria_IdMercadoria",
                table: "Saida");

            migrationBuilder.DropIndex(
                name: "IX_Saida_IdMercadoria",
                table: "Saida");

            migrationBuilder.DropIndex(
                name: "IX_Entrada_IdMercadoria",
                table: "Entrada");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Mercadoria_IdEntrada",
                table: "Entrada",
                column: "IdEntrada",
                principalTable: "Mercadoria",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Saida_Mercadoria_IdSaida",
                table: "Saida",
                column: "IdSaida",
                principalTable: "Mercadoria",
                principalColumn: "Id");
        }
    }
}
