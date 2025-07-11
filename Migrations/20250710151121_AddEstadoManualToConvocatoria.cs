using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackInovationMap.Migrations
{
    /// <inheritdoc />
    public partial class AddEstadoManualToConvocatoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstadoManual",
                table: "Convocatorias",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoManual",
                table: "Convocatorias");
        }
    }
}
