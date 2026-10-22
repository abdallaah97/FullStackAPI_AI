using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackAPI_AI.Migrations
{
    /// <inheritdoc />
    public partial class FixTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProfiles_Users_UserId",
                table: "CompanyProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProfiles_Users_UserId",
                table: "PersonProfiles");

            migrationBuilder.DropIndex(
                name: "IX_PersonProfiles_UserId",
                table: "PersonProfiles");

            migrationBuilder.DropIndex(
                name: "IX_CompanyProfiles_UserId",
                table: "CompanyProfiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CompanyProfiles");

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonProfileId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyProfileId",
                table: "Users",
                column: "CompanyProfileId",
                unique: true,
                filter: "[CompanyProfileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonProfileId",
                table: "Users",
                column: "PersonProfileId",
                unique: true,
                filter: "[PersonProfileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CompanyProfiles_CompanyProfileId",
                table: "Users",
                column: "CompanyProfileId",
                principalTable: "CompanyProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PersonProfiles_PersonProfileId",
                table: "Users",
                column: "PersonProfileId",
                principalTable: "PersonProfiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CompanyProfiles_CompanyProfileId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_PersonProfiles_PersonProfileId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyProfileId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PersonProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonProfileId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PersonProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CompanyProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PersonProfiles_UserId",
                table: "PersonProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfiles_UserId",
                table: "CompanyProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProfiles_Users_UserId",
                table: "CompanyProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProfiles_Users_UserId",
                table: "PersonProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
