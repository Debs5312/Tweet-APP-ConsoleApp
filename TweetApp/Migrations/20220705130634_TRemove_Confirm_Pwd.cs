using Microsoft.EntityFrameworkCore.Migrations;

namespace TweetApp_DAO.Migrations
{
    public partial class TRemove_Confirm_Pwd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "TWUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "TWUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
