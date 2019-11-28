using Microsoft.EntityFrameworkCore.Migrations;

namespace WebFarmacia.Web.Migrations
{
    public partial class complete2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailabe",
                table: "Medicinas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsAvailabe",
                table: "Medicinas",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
