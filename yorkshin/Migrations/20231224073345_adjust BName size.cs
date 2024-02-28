using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yorkshin.Migrations
{
    /// <inheritdoc />
    public partial class adjustBNamesize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_BookBid",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "BName",
                table: "Book",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_BookBid",
                table: "Order",
                column: "BookBid",
                unique: true,
                filter: "[BookBid] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_BookBid",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "BName",
                table: "Book",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_BookBid",
                table: "Order",
                column: "BookBid");
        }
    }
}
