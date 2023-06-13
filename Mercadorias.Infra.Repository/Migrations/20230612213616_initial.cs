using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercadorias.Infra.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mercadoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroRegistro = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercadoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    IdEntrada = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeEntrada = table.Column<int>(type: "int", nullable: false),
                    DataHoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocalEntrada = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdMercadoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.IdEntrada);
                    table.ForeignKey(
                        name: "FK_Entrada_Mercadoria_IdEntrada",
                        column: x => x.IdEntrada,
                        principalTable: "Mercadoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Saida",
                columns: table => new
                {
                    IdSaida = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeSaida = table.Column<int>(type: "int", nullable: false),
                    DataHoraSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocalSaida = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdMercadoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saida", x => x.IdSaida);
                    table.ForeignKey(
                        name: "FK_Saida_Mercadoria_IdSaida",
                        column: x => x.IdSaida,
                        principalTable: "Mercadoria",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "Saida");

            migrationBuilder.DropTable(
                name: "Mercadoria");
        }
    }
}
