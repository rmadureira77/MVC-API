using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _01DAL.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empregados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeEmpregado = table.Column<string>(nullable: true),
                    NumeroEmpregado = table.Column<int>(nullable: false),
                    UserEmpregado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empregados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faturas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroFatura = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    IdEmpregado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faturas_Empregados_IdEmpregado",
                        column: x => x.IdEmpregado,
                        principalTable: "Empregados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeProduto = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    Preco = table.Column<float>(nullable: false),
                    IdEmpregado = table.Column<int>(nullable: false),
                    EmpregadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Empregados_EmpregadoId",
                        column: x => x.EmpregadoId,
                        principalTable: "Empregados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinhasDeFatura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuantidadeLinha = table.Column<int>(nullable: false),
                    PrecoLinha = table.Column<float>(nullable: false),
                    IdProduto = table.Column<int>(nullable: false),
                    IdFaturas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhasDeFatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinhasDeFatura_Faturas_IdFaturas",
                        column: x => x.IdFaturas,
                        principalTable: "Faturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinhasDeFatura_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faturas_IdEmpregado",
                table: "Faturas",
                column: "IdEmpregado");

            migrationBuilder.CreateIndex(
                name: "IX_LinhasDeFatura_IdFaturas",
                table: "LinhasDeFatura",
                column: "IdFaturas");

            migrationBuilder.CreateIndex(
                name: "IX_LinhasDeFatura_IdProduto",
                table: "LinhasDeFatura",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_EmpregadoId",
                table: "Produtos",
                column: "EmpregadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinhasDeFatura");

            migrationBuilder.DropTable(
                name: "Faturas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Empregados");
        }
    }
}
