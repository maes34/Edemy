using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class User_Table_TempPassword_Field_Edited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TempPassword",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TempPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
