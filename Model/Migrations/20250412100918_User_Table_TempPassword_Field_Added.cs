using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class User_Table_TempPassword_Field_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempPassword",
                table: "Users");
        }
    }
}
