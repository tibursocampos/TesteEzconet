using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteEzconet.Persistence.Migrations
{
    public partial class CriandoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    SexoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Sexos",
                columns: table => new
                {
                    SexoId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.SexoId);
                    table.ForeignKey(
                        name: "FK_Sexos_Usuarios_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sexos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
