using Microsoft.EntityFrameworkCore.Migrations;

namespace Pitangueira.Repository.Migrations
{
    public partial class Alteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Atendimento");

            migrationBuilder.AddColumn<long>(
                name: "TipoAtendimentoId",
                table: "Atendimento",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoAtendimento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAtendimento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_TipoAtendimentoId",
                table: "Atendimento",
                column: "TipoAtendimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_TipoAtendimento_TipoAtendimentoId",
                table: "Atendimento",
                column: "TipoAtendimentoId",
                principalTable: "TipoAtendimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_TipoAtendimento_TipoAtendimentoId",
                table: "Atendimento");

            migrationBuilder.DropTable(
                name: "TipoAtendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_TipoAtendimentoId",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "TipoAtendimentoId",
                table: "Atendimento");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Atendimento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
