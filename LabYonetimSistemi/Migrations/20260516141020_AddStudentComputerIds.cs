using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabYonetimSistemi.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentComputerIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComputerIds",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerIds",
                table: "Students");
        }
    }
}
