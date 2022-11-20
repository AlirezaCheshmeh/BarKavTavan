using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarKavTavan.Migrations
{
    /// <inheritdoc />
    public partial class initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "Blog");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
