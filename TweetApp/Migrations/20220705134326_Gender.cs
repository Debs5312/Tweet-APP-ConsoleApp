using Microsoft.EntityFrameworkCore.Migrations;

namespace TweetApp_DAO.Migrations
{
    public partial class Gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gender",
                table: "TWUser",
                newName: "Gender");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "TWUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "TWUser",
                newName: "gender");

            migrationBuilder.AlterColumn<int>(
                name: "gender",
                table: "TWUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
