using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebFarmacia.Web.Migrations
{
    public partial class completeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoMedicinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMedicinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    imageUrl = table.Column<string>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Tipo = table.Column<string>(maxLength: 50, nullable: false),
                    Publicacion = table.Column<DateTime>(nullable: false),
                    Precio = table.Column<string>(maxLength: 20, nullable: true),
                    TipoMedicinasId = table.Column<int>(nullable: true),
                    OwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicinas_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicinas_TipoMedicinas_TipoMedicinasId",
                        column: x => x.TipoMedicinasId,
                        principalTable: "TipoMedicinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicinas_OwnerId",
                table: "Medicinas",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicinas_TipoMedicinasId",
                table: "Medicinas",
                column: "TipoMedicinasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicinas");

            migrationBuilder.DropTable(
                name: "TipoMedicinas");
        }
    }
}
