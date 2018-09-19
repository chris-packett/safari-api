using Microsoft.EntityFrameworkCore.Migrations;

namespace safariapi.Migrations
{
    public partial class AlteredLocationOfLastSeenTypeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocationOfLastSeen",
                table: "Animals",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LocationOfLastSeen",
                table: "Animals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
