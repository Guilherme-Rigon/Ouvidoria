using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ouvidoria.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    PerfilId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.PerfilId);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    SetorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.SetorId);
                });

            migrationBuilder.CreateTable(
                name: "TiposSolicitacao",
                columns: table => new
                {
                    TipoSolicitacaoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSolicitacao", x => x.TipoSolicitacaoId);
                });

            migrationBuilder.CreateTable(
                name: "Manifestacoes",
                columns: table => new
                {
                    ManifestacaoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilId = table.Column<long>(type: "bigint", nullable: false),
                    TipoSolicitacaoId = table.Column<long>(type: "bigint", nullable: false),
                    SetorId = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Celular = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Campus = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Curso = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Assunto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Detalhe = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manifestacoes", x => x.ManifestacaoId);
                    table.ForeignKey(
                        name: "FK_Manifestacoes_Perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfis",
                        principalColumn: "PerfilId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manifestacoes_Setores_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setores",
                        principalColumn: "SetorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manifestacoes_TiposSolicitacao_TipoSolicitacaoId",
                        column: x => x.TipoSolicitacaoId,
                        principalTable: "TiposSolicitacao",
                        principalColumn: "TipoSolicitacaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    RespostaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManifestacaoId = table.Column<long>(type: "bigint", nullable: false),
                    CaminhoAnexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Conteudo = table.Column<string>(type: "varchar(600)", maxLength: 600, nullable: true),
                    CadastradoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.RespostaId);
                    table.ForeignKey(
                        name: "FK_Respostas_Manifestacoes_ManifestacaoId",
                        column: x => x.ManifestacaoId,
                        principalTable: "Manifestacoes",
                        principalColumn: "ManifestacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Perfis",
                columns: new[] { "PerfilId", "AtualizadoEm", "CadastradoEm", "Nome" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 3, 7, 16, 15, 50, 487, DateTimeKind.Local).AddTicks(9032), new DateTime(2021, 3, 7, 16, 15, 50, 486, DateTimeKind.Local).AddTicks(9288), "Aluno" },
                    { 2L, new DateTime(2021, 3, 7, 16, 15, 50, 488, DateTimeKind.Local).AddTicks(80), new DateTime(2021, 3, 7, 16, 15, 50, 488, DateTimeKind.Local).AddTicks(65), "Pais de Aluno" },
                    { 3L, new DateTime(2021, 3, 7, 16, 15, 50, 488, DateTimeKind.Local).AddTicks(105), new DateTime(2021, 3, 7, 16, 15, 50, 488, DateTimeKind.Local).AddTicks(104), "Professor" },
                    { 4L, new DateTime(2021, 3, 7, 16, 15, 50, 488, DateTimeKind.Local).AddTicks(108), new DateTime(2021, 3, 7, 16, 15, 50, 488, DateTimeKind.Local).AddTicks(107), "Funcionário" },
                    { 5L, new DateTime(2021, 3, 7, 16, 15, 50, 488, DateTimeKind.Local).AddTicks(111), new DateTime(2021, 3, 7, 16, 15, 50, 488, DateTimeKind.Local).AddTicks(110), "Visitante" }
                });

            migrationBuilder.InsertData(
                table: "Setores",
                columns: new[] { "SetorId", "AtualizadoEm", "CadastradoEm", "Email", "Nome" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(3015), new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(3011), "biblioteca@gmail.com", "Biblioteca" },
                    { 2L, new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(3888), new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(3884), "centroatendimento@gmail.com", "Centro de Atendimento" },
                    { 3L, new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(3921), new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(3920), "financeiro@gmail.com", "Financeiro" }
                });

            migrationBuilder.InsertData(
                table: "TiposSolicitacao",
                columns: new[] { "TipoSolicitacaoId", "AtualizadoEm", "CadastradoEm", "Nome" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(1889), new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(1878), "Elogio" },
                    { 2L, new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(2525), new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(2520), "Reclamação" },
                    { 3L, new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(2543), new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(2542), "Sugestão" },
                    { 4L, new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(2546), new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(2545), "Outro" }
                });

            migrationBuilder.InsertData(
                table: "Manifestacoes",
                columns: new[] { "ManifestacaoId", "Assunto", "AtualizadoEm", "CadastradoEm", "Campus", "Celular", "Curso", "Detalhe", "Email", "Nome", "PerfilId", "SetorId", "Telefone", "TipoSolicitacaoId" },
                values: new object[] { 1L, "Grande Disponibilidade de Livros", new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(4413), new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(4408), "UGB-VR", "(24)99922-5355", null, "É a maior e melhor biblioteca que vi entre as 3 unidades", "guilherme.rigon1988@gmail.com", "Guilherme Luiz Simões Rigon", 1L, 1L, "(24)3350-4146", 1L });

            migrationBuilder.InsertData(
                table: "Manifestacoes",
                columns: new[] { "ManifestacaoId", "Assunto", "AtualizadoEm", "CadastradoEm", "Campus", "Celular", "Curso", "Detalhe", "Email", "Nome", "PerfilId", "SetorId", "Telefone", "TipoSolicitacaoId" },
                values: new object[] { 2L, "Mensalidade", new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(6770), new DateTime(2021, 3, 7, 16, 15, 50, 489, DateTimeKind.Local).AddTicks(6765), "UGB-VR", "(24)99922-5355", null, "Permitir débito em conta.", "joao@joao.com", "João Figueiredo", 2L, 3L, "(24)3350-4146", 3L });

            migrationBuilder.CreateIndex(
                name: "IX_Manifestacoes_PerfilId",
                table: "Manifestacoes",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifestacoes_SetorId",
                table: "Manifestacoes",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifestacoes_TipoSolicitacaoId",
                table: "Manifestacoes",
                column: "TipoSolicitacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_ManifestacaoId",
                table: "Respostas",
                column: "ManifestacaoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respostas");

            migrationBuilder.DropTable(
                name: "Manifestacoes");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "Setores");

            migrationBuilder.DropTable(
                name: "TiposSolicitacao");
        }
    }
}
