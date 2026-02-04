using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SwaggerControl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Point>(
                name: "Location",
                table: "realestates",
                type: "geometry(Point,4326)",
                nullable: false,
                oldClrType: typeof(Point),
                oldType: "geometry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Point>(
                name: "Location",
                table: "realestates",
                type: "geometry",
                nullable: false,
                oldClrType: typeof(Point),
                oldType: "geometry(Point,4326)");
        }
    }
}
