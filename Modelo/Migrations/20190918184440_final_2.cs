using Microsoft.EntityFrameworkCore.Migrations;

namespace _01DAL.Migrations
{
    public partial class final_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Preco",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
