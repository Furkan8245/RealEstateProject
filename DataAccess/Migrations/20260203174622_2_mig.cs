using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _2_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstates",
                table: "RealEstates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyTypes",
                table: "PropertyTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Neighborhoods",
                table: "Neighborhoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "UserOperationClaims",
                newName: "useroperationclaims");

            migrationBuilder.RenameTable(
                name: "RealEstates",
                newName: "realestates");

            migrationBuilder.RenameTable(
                name: "PropertyTypes",
                newName: "propertytypes");

            migrationBuilder.RenameTable(
                name: "OperationClaims",
                newName: "operationclaims");

            migrationBuilder.RenameTable(
                name: "Neighborhoods",
                newName: "neighborhoods");

            migrationBuilder.RenameTable(
                name: "Districts",
                newName: "districts");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "cities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_useroperationclaims",
                table: "useroperationclaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_realestates",
                table: "realestates",
                column: "RealEstateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_propertytypes",
                table: "propertytypes",
                column: "PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_operationclaims",
                table: "operationclaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_neighborhoods",
                table: "neighborhoods",
                column: "NeighborhoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_districts",
                table: "districts",
                column: "DistrictId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                table: "cities",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_useroperationclaims",
                table: "useroperationclaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_realestates",
                table: "realestates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_propertytypes",
                table: "propertytypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operationclaims",
                table: "operationclaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_neighborhoods",
                table: "neighborhoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_districts",
                table: "districts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                table: "cities");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "useroperationclaims",
                newName: "UserOperationClaims");

            migrationBuilder.RenameTable(
                name: "realestates",
                newName: "RealEstates");

            migrationBuilder.RenameTable(
                name: "propertytypes",
                newName: "PropertyTypes");

            migrationBuilder.RenameTable(
                name: "operationclaims",
                newName: "OperationClaims");

            migrationBuilder.RenameTable(
                name: "neighborhoods",
                newName: "Neighborhoods");

            migrationBuilder.RenameTable(
                name: "districts",
                newName: "Districts");

            migrationBuilder.RenameTable(
                name: "cities",
                newName: "Cities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstates",
                table: "RealEstates",
                column: "RealEstateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyTypes",
                table: "PropertyTypes",
                column: "PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Neighborhoods",
                table: "Neighborhoods",
                column: "NeighborhoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "DistrictId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityId");
        }
    }
}
