using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAreaAnalysisTableü : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Geometry>(
                name: "Geometry",
                table: "areaanalyses",
                type: "geometry(Geometry,4326)",
                nullable: false,
                oldClrType: typeof(Geometry),
                oldType: "geometry");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "areaanalyses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "areaanalyses");

            migrationBuilder.AlterColumn<Geometry>(
                name: "Geometry",
                table: "areaanalyses",
                type: "geometry",
                nullable: false,
                oldClrType: typeof(Geometry),
                oldType: "geometry(Geometry,4326)");
        }
    }
}
