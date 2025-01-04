using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateotptable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailOrMobile",
                table: "Otps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailOrMobile",
                table: "Otps");
        }
    }
}
