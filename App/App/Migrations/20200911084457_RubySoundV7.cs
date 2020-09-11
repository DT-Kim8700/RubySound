using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class RubySoundV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communitys_AspNetUsers_AccountUserId",
                table: "Communitys");

            migrationBuilder.DropIndex(
                name: "IX_Communitys_AccountUserId",
                table: "Communitys");

            migrationBuilder.DropColumn(
                name: "AccountUserId",
                table: "Communitys");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Communitys",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Communitys_Id",
                table: "Communitys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communitys_AspNetUsers_Id",
                table: "Communitys",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communitys_AspNetUsers_Id",
                table: "Communitys");

            migrationBuilder.DropIndex(
                name: "IX_Communitys_Id",
                table: "Communitys");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Communitys");

            migrationBuilder.AddColumn<string>(
                name: "AccountUserId",
                table: "Communitys",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Communitys_AccountUserId",
                table: "Communitys",
                column: "AccountUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Communitys_AspNetUsers_AccountUserId",
                table: "Communitys",
                column: "AccountUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
