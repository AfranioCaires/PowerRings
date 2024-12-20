using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LordOfRings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aneis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Poder = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Portador = table.Column<int>(type: "int", nullable: false),
                    ForjadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aneis", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aneis");
        }
    }
}
