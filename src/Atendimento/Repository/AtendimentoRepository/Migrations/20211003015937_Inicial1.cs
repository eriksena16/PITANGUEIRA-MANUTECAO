using Microsoft.EntityFrameworkCore.Migrations;

namespace Pitangueira.Repository.AtendimentoRepository.Migrations
{
    public partial class Inicial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Usuario_UsuarioId1",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_UsuarioId1",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Atendimento");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioId",
                table: "Atendimento",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_UsuarioId",
                table: "Atendimento",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Usuario_UsuarioId",
                table: "Atendimento",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Usuario_UsuarioId",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_UsuarioId",
                table: "Atendimento");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Atendimento",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UsuarioId1",
                table: "Atendimento",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_UsuarioId1",
                table: "Atendimento",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Usuario_UsuarioId1",
                table: "Atendimento",
                column: "UsuarioId1",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
