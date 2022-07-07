using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dtmsservicemaster.Migrations
{
    public partial class RemakeVendorField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Vendors",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Vendors",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Vendors",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Vendors",
                newName: "address");
        }
    }
}
