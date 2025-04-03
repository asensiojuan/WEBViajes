using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBViajes.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampoNotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChoferId",
                table: "Viajes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Chofer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chofer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_ChoferId",
                table: "Viajes",
                column: "ChoferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_Chofer_ChoferId",
                table: "Viajes",
                column: "ChoferId",
                principalTable: "Chofer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_Chofer_ChoferId",
                table: "Viajes");

            migrationBuilder.DropTable(
                name: "Chofer");

            migrationBuilder.DropIndex(
                name: "IX_Viajes_ChoferId",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "ChoferId",
                table: "Viajes");
        }
    }
}
