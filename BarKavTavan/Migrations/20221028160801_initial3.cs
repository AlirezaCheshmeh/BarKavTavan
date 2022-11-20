using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarKavTavan.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    blogid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    titleb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    litledes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Roleid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.blogid);
                    table.ForeignKey(
                        name: "FK_Blog_Role_Roleid",
                        column: x => x.Roleid,
                        principalTable: "Role",
                        principalColumn: "Roleid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Roleid",
                table: "Blog",
                column: "Roleid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");
        }
    }
}
