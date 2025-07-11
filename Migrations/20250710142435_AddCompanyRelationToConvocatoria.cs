using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackInovationMap.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyRelationToConvocatoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Convocatorias",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Convocatorias_CompanyId",
                table: "Convocatorias",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Convocatorias_Companies_CompanyId",
                table: "Convocatorias",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convocatorias_Companies_CompanyId",
                table: "Convocatorias");

            migrationBuilder.DropIndex(
                name: "IX_Convocatorias_CompanyId",
                table: "Convocatorias");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Convocatorias");
        }
    }
}
