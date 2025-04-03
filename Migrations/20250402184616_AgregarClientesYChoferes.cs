using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBViajes.Migrations
{
    /// <inheritdoc />
    public partial class AgregarClientesYChoferes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_Chofer_ChoferId",
                table: "Viajes");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_Cliente_ClienteId",
                table: "Viajes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chofer",
                table: "Chofer");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.RenameTable(
                name: "Chofer",
                newName: "Choferes");

            migrationBuilder.RenameColumn(
                name: "Destinatario",
                table: "Viajes",
                newName: "Pasajero");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choferes",
                table: "Choferes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_Choferes_ChoferId",
                table: "Viajes",
                column: "ChoferId",
                principalTable: "Choferes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_Clientes_ClienteId",
                table: "Viajes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_Choferes_ChoferId",
                table: "Viajes");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_Clientes_ClienteId",
                table: "Viajes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choferes",
                table: "Choferes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.RenameTable(
                name: "Choferes",
                newName: "Chofer");

            migrationBuilder.RenameColumn(
                name: "Pasajero",
                table: "Viajes",
                newName: "Destinatario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chofer",
                table: "Chofer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_Chofer_ChoferId",
                table: "Viajes",
                column: "ChoferId",
                principalTable: "Chofer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_Cliente_ClienteId",
                table: "Viajes",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
