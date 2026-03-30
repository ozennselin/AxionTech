using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PictureNewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "ProductPicture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrjinalName",
                schema: "dbo",
                table: "ProductPicture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "ProductPicture");

            migrationBuilder.DropColumn(
                name: "OrjinalName",
                schema: "dbo",
                table: "ProductPicture");
        }
    }
}
