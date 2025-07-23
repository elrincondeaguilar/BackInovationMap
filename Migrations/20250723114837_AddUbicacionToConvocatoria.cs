using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackInovationMap.Migrations
{
    /// <inheritdoc />
    public partial class AddUbicacionToConvocatoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ubicacion",
                table: "Convocatorias",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "Convocatorias");
        }
    }
}
