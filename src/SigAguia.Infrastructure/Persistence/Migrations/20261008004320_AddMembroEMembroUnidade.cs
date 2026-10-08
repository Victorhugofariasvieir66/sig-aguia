using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SigAguia.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMembroEMembroUnidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "membro",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    pessoa_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_ingresso = table.Column<DateOnly>(type: "date", nullable: true),
                    situacao = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    criado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membro", x => x.id);
                    table.ForeignKey(
                        name: "FK_membro_pessoa_pessoa_id",
                        column: x => x.pessoa_id,
                        principalTable: "pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "membro_unidade",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    membro_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unidade_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tipo_vinculo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    data_inicio = table.Column<DateOnly>(type: "date", nullable: false),
                    data_fim = table.Column<DateOnly>(type: "date", nullable: true),
                    criado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membro_unidade", x => x.id);
                    table.ForeignKey(
                        name: "FK_membro_unidade_membro_membro_id",
                        column: x => x.membro_id,
                        principalTable: "membro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_membro_unidade_unidade_unidade_id",
                        column: x => x.unidade_id,
                        principalTable: "unidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_membro_pessoa_id",
                table: "membro",
                column: "pessoa_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_membro_unidade_membro_id",
                table: "membro_unidade",
                column: "membro_id",
                unique: true,
                filter: "data_fim IS NULL AND tipo_vinculo = 'Principal'");

            migrationBuilder.CreateIndex(
                name: "IX_membro_unidade_unidade_id",
                table: "membro_unidade",
                column: "unidade_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "membro_unidade");

            migrationBuilder.DropTable(
                name: "membro");
        }
    }
}
