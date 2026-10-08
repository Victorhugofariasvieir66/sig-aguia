using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SigAguia.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUnidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "unidade",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    eh_matriz = table.Column<bool>(type: "boolean", nullable: false),
                    ativa = table.Column<bool>(type: "boolean", nullable: false),
                    criado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidade", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_unidade_eh_matriz",
                table: "unidade",
                column: "eh_matriz",
                unique: true,
                filter: "eh_matriz = true");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "unidade");
        }
    }
}
