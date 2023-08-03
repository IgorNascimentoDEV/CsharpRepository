using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    /// <inheritdoc />
    public partial class RecriandoNomeTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_tb_profissional_especialidade_Especialidades_id_especialida~",
                table: "tb_profissional_especialidade");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_profissional_especialidade_Profissionais_id_profissional",
                table: "tb_profissional_especialidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profissionais",
                table: "Profissionais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades");

            migrationBuilder.RenameTable(
                name: "Profissionais",
                newName: "tb_profissional");

            migrationBuilder.RenameTable(
                name: "Pacientes",
                newName: "tb_paciente");

            migrationBuilder.RenameTable(
                name: "Especialidades",
                newName: "tb_especialidades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_profissional",
                table: "tb_profissional",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_paciente",
                table: "tb_paciente",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_especialidades",
                table: "tb_especialidades",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_especialidades_id_especialidade",
                table: "tb_consulta",
                column: "id_especialidade",
                principalTable: "tb_especialidades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_paciente_id_paciente",
                table: "tb_consulta",
                column: "id_paciente",
                principalTable: "tb_paciente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_profissional_id_profissional",
                table: "tb_consulta",
                column: "id_profissional",
                principalTable: "tb_profissional",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_profissional_especialidade_tb_especialidades_id_especial~",
                table: "tb_profissional_especialidade",
                column: "id_especialidade",
                principalTable: "tb_especialidades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_profissional_especialidade_tb_profissional_id_profission~",
                table: "tb_profissional_especialidade",
                column: "id_profissional",
                principalTable: "tb_profissional",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_especialidades_id_especialidade",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_paciente_id_paciente",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_profissional_id_profissional",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_profissional_especialidade_tb_especialidades_id_especial~",
                table: "tb_profissional_especialidade");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_profissional_especialidade_tb_profissional_id_profission~",
                table: "tb_profissional_especialidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_profissional",
                table: "tb_profissional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_paciente",
                table: "tb_paciente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_especialidades",
                table: "tb_especialidades");

            migrationBuilder.RenameTable(
                name: "tb_profissional",
                newName: "Profissionais");

            migrationBuilder.RenameTable(
                name: "tb_paciente",
                newName: "Pacientes");

            migrationBuilder.RenameTable(
                name: "tb_especialidades",
                newName: "Especialidades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profissionais",
                table: "Profissionais",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades",
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

            migrationBuilder.AddForeignKey(
                name: "FK_tb_profissional_especialidade_Especialidades_id_especialida~",
                table: "tb_profissional_especialidade",
                column: "id_especialidade",
                principalTable: "Especialidades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_profissional_especialidade_Profissionais_id_profissional",
                table: "tb_profissional_especialidade",
                column: "id_profissional",
                principalTable: "Profissionais",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
