using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    /// <inheritdoc />
    public partial class RecriandoNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Especialidades_id_especialidade",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_id_paciente",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Profissionais_id_profissional",
                table: "Consultas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas");

            migrationBuilder.RenameTable(
                name: "Consultas",
                newName: "tb_consulta");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_id_profissional",
                table: "tb_consulta",
                newName: "IX_tb_consulta_id_profissional");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_id_paciente",
                table: "tb_consulta",
                newName: "IX_tb_consulta_id_paciente");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_id_especialidade",
                table: "tb_consulta",
                newName: "IX_tb_consulta_id_especialidade");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_consulta",
                table: "tb_consulta",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_Especialidades_id_especialidade",
                table: "tb_consulta",
                column: "id_especialidade",
                principalTable: "Especialidades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_Pacientes_id_paciente",
                table: "tb_consulta",
                column: "id_paciente",
                principalTable: "Pacientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_Profissionais_id_profissional",
                table: "tb_consulta",
                column: "id_profissional",
                principalTable: "Profissionais",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_Especialidades_id_especialidade",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_Pacientes_id_paciente",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_Profissionais_id_profissional",
                table: "tb_consulta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_consulta",
                table: "tb_consulta");

            migrationBuilder.RenameTable(
                name: "tb_consulta",
                newName: "Consultas");

            migrationBuilder.RenameIndex(
                name: "IX_tb_consulta_id_profissional",
                table: "Consultas",
                newName: "IX_Consultas_id_profissional");

            migrationBuilder.RenameIndex(
                name: "IX_tb_consulta_id_paciente",
                table: "Consultas",
                newName: "IX_Consultas_id_paciente");

            migrationBuilder.RenameIndex(
                name: "IX_tb_consulta_id_especialidade",
                table: "Consultas",
                newName: "IX_Consultas_id_especialidade");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Especialidades_id_especialidade",
                table: "Consultas",
                column: "id_especialidade",
                principalTable: "Especialidades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_id_paciente",
                table: "Consultas",
                column: "id_paciente",
                principalTable: "Pacientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Profissionais_id_profissional",
                table: "Consultas",
                column: "id_profissional",
                principalTable: "Profissionais",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
