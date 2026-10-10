using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SigAguia.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEstruturaMinisterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cargo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "funcao",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ativa = table.Column<bool>(type: "boolean", nullable: false),
                    criado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ministerio",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ministerio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "membro_cargo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    membro_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cargo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_inicio = table.Column<DateOnly>(type: "date", nullable: false),
                    data_fim = table.Column<DateOnly>(type: "date", nullable: true),
                    criado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membro_cargo", x => x.id);
                    table.ForeignKey(
                        name: "FK_membro_cargo_cargo_cargo_id",
                        column: x => x.cargo_id,
                        principalTable: "cargo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_membro_cargo_membro_membro_id",
                        column: x => x.membro_id,
                        principalTable: "membro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "membro_funcao",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    membro_id = table.Column<Guid>(type: "uuid", nullable: false),
                    funcao_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_inicio = table.Column<DateOnly>(type: "date", nullable: false),
                    data_fim = table.Column<DateOnly>(type: "date", nullable: true),
                    criado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membro_funcao", x => x.id);
                    table.ForeignKey(
                        name: "FK_membro_funcao_funcao_funcao_id",
                        column: x => x.funcao_id,
                        principalTable: "funcao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_membro_funcao_membro_membro_id",
                        column: x => x.membro_id,
                        principalTable: "membro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lideranca_ministerio",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ministerio_id = table.Column<Guid>(type: "uuid", nullable: false),
                    membro_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tipo_lideranca = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    data_inicio = table.Column<DateOnly>(type: "date", nullable: false),
                    data_fim = table.Column<DateOnly>(type: "date", nullable: true),
                    criado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lideranca_ministerio", x => x.id);
                    table.ForeignKey(
                        name: "FK_lideranca_ministerio_membro_membro_id",
                        column: x => x.membro_id,
                        principalTable: "membro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_lideranca_ministerio_ministerio_ministerio_id",
                        column: x => x.ministerio_id,
                        principalTable: "ministerio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "membro_ministerio",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    membro_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ministerio_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_inicio = table.Column<DateOnly>(type: "date", nullable: false),
                    data_fim = table.Column<DateOnly>(type: "date", nullable: true),
                    criado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membro_ministerio", x => x.id);
                    table.ForeignKey(
                        name: "FK_membro_ministerio_membro_membro_id",
                        column: x => x.membro_id,
                        principalTable: "membro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_membro_ministerio_ministerio_ministerio_id",
                        column: x => x.ministerio_id,
                        principalTable: "ministerio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lideranca_ministerio_membro_id",
                table: "lideranca_ministerio",
                column: "membro_id");

            migrationBuilder.CreateIndex(
                name: "IX_lideranca_ministerio_ministerio_id",
                table: "lideranca_ministerio",
                column: "ministerio_id");

            migrationBuilder.CreateIndex(
                name: "IX_membro_cargo_cargo_id",
                table: "membro_cargo",
                column: "cargo_id");

            migrationBuilder.CreateIndex(
                name: "IX_membro_cargo_membro_id",
                table: "membro_cargo",
                column: "membro_id");

            migrationBuilder.CreateIndex(
                name: "IX_membro_funcao_funcao_id",
                table: "membro_funcao",
                column: "funcao_id");

            migrationBuilder.CreateIndex(
                name: "IX_membro_funcao_membro_id",
                table: "membro_funcao",
                column: "membro_id");

            migrationBuilder.CreateIndex(
                name: "IX_membro_ministerio_membro_id",
                table: "membro_ministerio",
                column: "membro_id");

            migrationBuilder.CreateIndex(
                name: "IX_membro_ministerio_ministerio_id",
                table: "membro_ministerio",
                column: "ministerio_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lideranca_ministerio");

            migrationBuilder.DropTable(
                name: "membro_cargo");

            migrationBuilder.DropTable(
                name: "membro_funcao");

            migrationBuilder.DropTable(
                name: "membro_ministerio");

            migrationBuilder.DropTable(
                name: "cargo");

            migrationBuilder.DropTable(
                name: "funcao");

            migrationBuilder.DropTable(
                name: "ministerio");
        }
    }
}
