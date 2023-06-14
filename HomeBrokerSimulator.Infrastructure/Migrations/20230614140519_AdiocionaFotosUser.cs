using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBrokerSimulator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdiocionaFotosUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "usuario",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "usuario",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "usuario");
        }
    }
}
