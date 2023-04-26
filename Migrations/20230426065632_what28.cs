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
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliverPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenAmount = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    PosterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliverPost_Accounts_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EaterPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PosterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EaterPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EaterPost_Accounts_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliverPostId = table.Column<int>(type: "int", nullable: true),
                    OrdererId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Accounts_OrdererId",
                        column: x => x.OrdererId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_DeliverPost_DeliverPostId",
                        column: x => x.DeliverPostId,
                        principalTable: "DeliverPost",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EaterPostAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EaterPostId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EaterPostAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EaterPostAccount_Accounts_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EaterPostAccount_EaterPost_EaterPostId",
                        column: x => x.EaterPostId,
                        principalTable: "EaterPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliverPost_PosterId",
                table: "DeliverPost",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_EaterPost_PosterId",
                table: "EaterPost",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_EaterPostAccount_BuyerId",
                table: "EaterPostAccount",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_EaterPostAccount_EaterPostId",
                table: "EaterPostAccount",
                column: "EaterPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliverPostId",
                table: "Order",
                column: "DeliverPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrdererId",
                table: "Order",
                column: "OrdererId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EaterPostAccount");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "EaterPost");

            migrationBuilder.DropTable(
                name: "DeliverPost");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
