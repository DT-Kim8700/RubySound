using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class RubySoundV8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonStatus",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "AccountUserId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "NEXT VALUE FOR shared.AccountUserIdSequence");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR shared.AccountUserIdSequence",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonStatus",
                table: "Schedules");

            migrationBuilder.AlterColumn<string>(
                name: "AccountUserId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "NEXT VALUE FOR shared.AccountUserIdSequence",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValueSql: "NEXT VALUE FOR shared.AccountUserIdSequence");
        }
    }
}
