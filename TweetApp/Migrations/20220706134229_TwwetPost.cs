using Microsoft.EntityFrameworkCore.Migrations;

namespace TweetApp_DAO.Migrations
{
    public partial class TwwetPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TWTweetpost",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostedBy = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userDetailsUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWTweetpost", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_TWTweetpost_TWUser_userDetailsUserId",
                        column: x => x.userDetailsUserId,
                        principalTable: "TWUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TWTweetpost_userDetailsUserId",
                table: "TWTweetpost",
                column: "userDetailsUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TWTweetpost");
        }
    }
}
