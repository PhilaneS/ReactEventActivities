using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FollowingEntityUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followings_AspNetUsers_ObserverId",
                table: "Followings");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_AspNetUsers_TargetId",
                table: "Followings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followings",
                table: "Followings");

            migrationBuilder.RenameTable(
                name: "Followings",
                newName: "userFollowings");

            migrationBuilder.RenameIndex(
                name: "IX_Followings_TargetId",
                table: "userFollowings",
                newName: "IX_userFollowings_TargetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userFollowings",
                table: "userFollowings",
                columns: new[] { "ObserverId", "TargetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_userFollowings_AspNetUsers_ObserverId",
                table: "userFollowings",
                column: "ObserverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userFollowings_AspNetUsers_TargetId",
                table: "userFollowings",
                column: "TargetId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userFollowings_AspNetUsers_ObserverId",
                table: "userFollowings");

            migrationBuilder.DropForeignKey(
                name: "FK_userFollowings_AspNetUsers_TargetId",
                table: "userFollowings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userFollowings",
                table: "userFollowings");

            migrationBuilder.RenameTable(
                name: "userFollowings",
                newName: "Followings");

            migrationBuilder.RenameIndex(
                name: "IX_userFollowings_TargetId",
                table: "Followings",
                newName: "IX_Followings_TargetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followings",
                table: "Followings",
                columns: new[] { "ObserverId", "TargetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_AspNetUsers_ObserverId",
                table: "Followings",
                column: "ObserverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_AspNetUsers_TargetId",
                table: "Followings",
                column: "TargetId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
