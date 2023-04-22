using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace what_u_gonna_eat.Migrations
{
    /// <inheritdoc />
    public partial class oat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depositors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliverPosts",
                table: "DeliverPosts");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "DeliverPosts");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "DeliverPosts");

            migrationBuilder.RenameTable(
                name: "DeliverPosts",
                newName: "DeliverPost");

            migrationBuilder.AddColumn<int>(
                name: "DeliverPostId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "DeliverPost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DurationInMinutes",
                table: "DeliverPost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliverPost",
                table: "DeliverPost",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_DeliverPostId",
                table: "Accounts",
                column: "DeliverPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_DeliverPost_DeliverPostId",
                table: "Accounts",
                column: "DeliverPostId",
                principalTable: "DeliverPost",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_DeliverPost_DeliverPostId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_DeliverPostId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliverPost",
                table: "DeliverPost");

            migrationBuilder.DropColumn(
                name: "DeliverPostId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "DeliverPost");

            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "DeliverPost");

            migrationBuilder.RenameTable(
                name: "DeliverPost",
                newName: "DeliverPosts");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "DeliverPosts",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "DeliverPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliverPosts",
                table: "DeliverPosts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Depositors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    postId = table.Column<int>(type: "int", nullable: false),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depositors_DeliverPosts_postId",
                        column: x => x.postId,
                        principalTable: "DeliverPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Depositors_postId",
                table: "Depositors",
                column: "postId");
        }
    }
}
