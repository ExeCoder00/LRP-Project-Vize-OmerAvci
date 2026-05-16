using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabYonetimSistemi.Migrations
{
    /// <inheritdoc />
    public partial class AddComputerType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Computers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Computers");
        }
    }
}
