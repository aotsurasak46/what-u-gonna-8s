using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace what_u_gonna_eat.Migrations
{
    /// <inheritdoc />
    public partial class what31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EaterPostAccount_Accounts_BuyerId",
                table: "EaterPostAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_EaterPostAccount_EaterPost_EaterPostId",
                table: "EaterPostAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EaterPostAccount",
                table: "EaterPostAccount");

            migrationBuilder.RenameTable(
                name: "EaterPostAccount",
                newName: "EaterPostAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_EaterPostAccount_EaterPostId",
                table: "EaterPostAccounts",
                newName: "IX_EaterPostAccounts_EaterPostId");

            migrationBuilder.RenameIndex(
                name: "IX_EaterPostAccount_BuyerId",
                table: "EaterPostAccounts",
                newName: "IX_EaterPostAccounts_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EaterPostAccounts",
                table: "EaterPostAccounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EaterPostAccounts_Accounts_BuyerId",
                table: "EaterPostAccounts",
                column: "BuyerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EaterPostAccounts_EaterPost_EaterPostId",
                table: "EaterPostAccounts",
                column: "EaterPostId",
                principalTable: "EaterPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EaterPostAccounts_Accounts_BuyerId",
                table: "EaterPostAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_EaterPostAccounts_EaterPost_EaterPostId",
                table: "EaterPostAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EaterPostAccounts",
                table: "EaterPostAccounts");

            migrationBuilder.RenameTable(
                name: "EaterPostAccounts",
                newName: "EaterPostAccount");

            migrationBuilder.RenameIndex(
                name: "IX_EaterPostAccounts_EaterPostId",
                table: "EaterPostAccount",
                newName: "IX_EaterPostAccount_EaterPostId");

            migrationBuilder.RenameIndex(
                name: "IX_EaterPostAccounts_BuyerId",
                table: "EaterPostAccount",
                newName: "IX_EaterPostAccount_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EaterPostAccount",
                table: "EaterPostAccount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EaterPostAccount_Accounts_BuyerId",
                table: "EaterPostAccount",
                column: "BuyerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EaterPostAccount_EaterPost_EaterPostId",
                table: "EaterPostAccount",
                column: "EaterPostId",
                principalTable: "EaterPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
