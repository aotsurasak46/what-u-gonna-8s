using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace what_u_gonna_eat.Migrations
{
    /// <inheritdoc />
    public partial class what30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliverPost_Accounts_PosterId",
                table: "DeliverPost");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Accounts_OrdererId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliverPost_DeliverPostId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliverPost",
                table: "DeliverPost");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "DeliverPost",
                newName: "DeliverPosts");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrdererId",
                table: "Orders",
                newName: "IX_Orders_OrdererId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DeliverPostId",
                table: "Orders",
                newName: "IX_Orders_DeliverPostId");

            migrationBuilder.RenameIndex(
                name: "IX_DeliverPost_PosterId",
                table: "DeliverPosts",
                newName: "IX_DeliverPosts_PosterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliverPosts",
                table: "DeliverPosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliverPosts_Accounts_PosterId",
                table: "DeliverPosts",
                column: "PosterId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Accounts_OrdererId",
                table: "Orders",
                column: "OrdererId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliverPosts_DeliverPostId",
                table: "Orders",
                column: "DeliverPostId",
                principalTable: "DeliverPosts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliverPosts_Accounts_PosterId",
                table: "DeliverPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Accounts_OrdererId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliverPosts_DeliverPostId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliverPosts",
                table: "DeliverPosts");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "DeliverPosts",
                newName: "DeliverPost");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrdererId",
                table: "Order",
                newName: "IX_Order_OrdererId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeliverPostId",
                table: "Order",
                newName: "IX_Order_DeliverPostId");

            migrationBuilder.RenameIndex(
                name: "IX_DeliverPosts_PosterId",
                table: "DeliverPost",
                newName: "IX_DeliverPost_PosterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliverPost",
                table: "DeliverPost",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliverPost_Accounts_PosterId",
                table: "DeliverPost",
                column: "PosterId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Accounts_OrdererId",
                table: "Order",
                column: "OrdererId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliverPost_DeliverPostId",
                table: "Order",
                column: "DeliverPostId",
                principalTable: "DeliverPost",
                principalColumn: "Id");
        }
    }
}
