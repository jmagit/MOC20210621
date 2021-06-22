using Microsoft.EntityFrameworkCore.Migrations;

namespace Curso.Data.Migrations
{
    public partial class UpdateContactos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tratamiento",
                table: "Contacto",
                type: "nvarchar(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tratamiento",
                table: "Contacto");
        }
    }
}
