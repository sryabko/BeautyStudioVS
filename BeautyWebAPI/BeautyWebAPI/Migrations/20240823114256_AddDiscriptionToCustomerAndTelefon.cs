using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscriptionToCustomerAndTelefon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discription",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Customers");
        }
    }
}
