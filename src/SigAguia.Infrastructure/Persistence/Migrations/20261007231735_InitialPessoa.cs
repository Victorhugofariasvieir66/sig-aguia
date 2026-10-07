using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SigAguia.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome_completo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    data_nascimento = table.Column<DateOnly>(type: "date", nullable: true),
                    telefone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    email = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: true),
                    estado_civil = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    foto_arquivo_id = table.Column<Guid>(type: "uuid", nullable: true),
                    criado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pessoa");
        }
    }
}
