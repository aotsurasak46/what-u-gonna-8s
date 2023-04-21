using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace what_u_gonna_eat.Migrations
{
    /// <inheritdoc />
    public partial class what28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EaterPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Restaurant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isClosed = table.Column<bool>(type: "bit", nullable: false),
                    BenefactorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOut = table.Column<int>(type: "int", nullable: false),
                    Menu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EaterPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EaterPosts_Account_accountId",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EaterPosts_accountId",
                table: "EaterPosts",
                column: "accountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EaterPosts");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
